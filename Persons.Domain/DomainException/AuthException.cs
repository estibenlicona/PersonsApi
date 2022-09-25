using Persons.Domain.Exceptions;
using System.Runtime.Serialization;

namespace Persons.Domain.DomainException
{
    [Serializable]
    public class AuthException : AppException
    {
        public AuthException() { }
        public AuthException(string message) : base(message) { }
        public AuthException(string message, System.Exception inner) : base(message, inner) { }
        protected AuthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
