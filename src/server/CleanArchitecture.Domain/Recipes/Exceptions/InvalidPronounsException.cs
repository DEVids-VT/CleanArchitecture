namespace CleanArchitecture.Domain.Recipes.Exceptions
{
    using CleanArchitecture.Domain.Common;
    using System.Diagnostics.CodeAnalysis;
    public class InvalidPhoneNumberException : BaseDomainException
    {
        [ExcludeFromCodeCoverage]
        public InvalidPhoneNumberException()
        {
            
        }
        public InvalidPhoneNumberException(string error) : base(error)
        {

        }

    }
}
