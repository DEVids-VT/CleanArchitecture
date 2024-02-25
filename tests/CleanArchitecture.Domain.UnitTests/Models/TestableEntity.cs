using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Common.Models;

namespace CleanArchitecture.Domain.UnitTests.Models
{
    public class TestableEntity : Entity<int>
    {
        public void TestRaiseEvent(IDomainEvent domainEvent)
        {
            RaiseEvent(domainEvent);
        }
    }
}
