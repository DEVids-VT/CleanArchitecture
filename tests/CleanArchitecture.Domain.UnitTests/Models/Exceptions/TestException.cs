using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.UnitTests.Models.Exceptions
{
    public class TestException : BaseDomainException
    {
        public TestException()
        {
            
        }

        public TestException(string message) : base(message)
        {
            
        }
    }
}
