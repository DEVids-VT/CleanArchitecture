namespace CleanArchitecture.Domain.Recipes.Exceptions
{
    using CleanArchitecture.Domain.Common;
    using System.Diagnostics.CodeAnalysis;

    [ExcludeFromCodeCoverage]
    public class InvalidProfileException : BaseDomainException
    {
        public InvalidProfileException()
        {

        }
        public InvalidProfileException(string error) : base(error)
        {

        }
    }
}
