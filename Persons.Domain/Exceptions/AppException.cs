using System.Runtime.Serialization;

namespace Persons.Domain.Exceptions
{
    [Serializable]
    public class AppException : Exception
    {
        public AppException() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, System.Exception inner) : base(message, inner) { }
        protected AppException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
