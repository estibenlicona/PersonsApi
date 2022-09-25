using System;

namespace Persons.Domain.Services
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DomainServiceAttribute : Attribute
    {
    }
}
