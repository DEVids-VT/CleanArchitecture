namespace CleanArchitecture.Domain.Recipes.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using CleanArchitecture.Domain.Common;

    [ExcludeFromCodeCoverage]
    public class InvalidIngredientException : BaseDomainException
    {
        public InvalidIngredientException()
        {

        }

        public InvalidIngredientException(string error) : base(error)
        {

        }
    }
}