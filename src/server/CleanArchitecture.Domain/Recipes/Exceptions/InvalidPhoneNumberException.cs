namespace CleanArchitecture.Domain.Recipes.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using CleanArchitecture.Domain.Common;

    [ExcludeFromCodeCoverage]
    public class InvalidPronounsException : BaseDomainException
    {
        public InvalidPronounsException()
        {
            
        }

        public InvalidPronounsException(string error) : base(error)
        {

        }

    }
}
