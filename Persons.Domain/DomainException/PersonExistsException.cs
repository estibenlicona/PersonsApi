using Persons.Domain.Exceptions;
using System.Runtime.Serialization;

namespace Persons.Domain.DomainException
{
    [Serializable]
    public class PersonExistsException : AppException
    {
        public PersonExistsException() { }
        public PersonExistsException(string message) : base(message) { }
        public PersonExistsException(string message, System.Exception inner) : base(message, inner) { }
        protected PersonExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
