using NSubstitute;
using Persons.Domain.Entities;
using Persons.Domain.Ports;
using Persons.Domain.Services;
using System.Linq.Expressions;

namespace Persons.Domain.Tests.PersonTests
{
    [TestClass]
    public class PersonServiceTests
    {
        IGenericRepository<Person> _personRespository = default!;
        PersonService _personService = default!;

        [TestInitialize]
        public void Init()
        {
            _personRespository = Substitute.For<IGenericRepository<Person>>();
            _personService = new PersonService(_personRespository);
        }

        [TestMethod]
        public async Task SuccessToListPersons()
        {
            List<Person> listPersons = new List<Person>()
            {
                new Person(new Guid("708C8BA3-87CA-4A8C-A5D7-253DC4E4F2E8"), "12548464", "Juan", "Alvarez"),
                new Person(new Guid("608C8BA3-87CA-4A8C-A5D7-253DC4E4F2E9"), "10280314", "Felipe", "Bueno"),
                new Person(new Guid("508C8BA3-87CA-4A8C-A5D7-253DC4E4F2E5"), "10924827", "Joel", "Licona"),
            };

            Tuple<IEnumerable<Person>, int> tuple = new Tuple<IEnumerable<Person>, int>(listPersons, listPersons.Count);
            _personRespository.ListAsync(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<Expression<Func<Person, bool>>>()).Returns(Task.FromResult(tuple));

            Tuple<IEnumerable<Person>, int> tupleEntity = await _personService.ListAsync(0, 10);
            Assert.AreEqual(tupleEntity, tupleEntity);
        }

        [TestMethod]
        public async Task SuccessToRegisterPerson()
        {
            Person person = new Person()
            {
                Document = "12548464",
                FirstName = "Juan",
                LastName = "Pepito"
            };

            Guid id = new Guid("708C8BA3-87CA-4A8C-A5D7-253DC4E4F2E8");
            _personRespository.AddAsync(Arg.Any<Person>()).Returns(Task.FromResult(new PersonDataBuilder().
                WithId(id)
                .WithDocument(person.Document)
                .WithFirstName(person.FirstName)
                .WithLastName(person.LastName)
                .Build()));

            Guid idEntity = await _personService.AddAsync(person);
            await _personRespository.Received().AddAsync(Arg.Is(person));
            Assert.IsNotNull(idEntity);
            Assert.AreEqual(id, idEntity);
        }

        [TestMethod]
        public async Task SuccessToEditPerson()
        {
            Person person = new Person()
            {
                Id = new Guid("708C8BA3-87CA-4A8C-A5D7-253DC4E4F2E8"),
                Document = "12548464",
                FirstName = "Juan Mauricio",
                LastName = "Ramirez"
            };

            await _personService.UpdateAsync(person);
            await _personRespository.Received().UpdateAsync(Arg.Is(person));
        }

        [TestMethod]
        public async Task SuccessToDletePerson()
        {
            Person person = new Person()
            {
                Id = new Guid("708C8BA3-87CA-4A8C-A5D7-253DC4E4F2E8")
            };

            await _personService.DeleteAsync(person);
            await _personRespository.Received().DeleteAsync(Arg.Is(person));
        }
    }
}