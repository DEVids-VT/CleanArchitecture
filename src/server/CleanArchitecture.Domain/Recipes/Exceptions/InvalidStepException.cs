namespace CleanArchitecture.Domain.Recipes.Exceptions
{
    using System.Diagnostics.CodeAnalysis;
    using CleanArchitecture.Domain.Common;

    [ExcludeFromCodeCoverage]
    public class InvalidStepExcepion : BaseDomainException
    {
        public InvalidStepExcepion()
        {

        }

        public InvalidStepExcepion(string error) : base(error)
        {

        }
    }
}