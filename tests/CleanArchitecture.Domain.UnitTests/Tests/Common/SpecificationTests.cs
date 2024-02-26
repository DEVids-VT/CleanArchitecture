namespace CleanArchitecture.Domain.UnitTests.Tests.Common
{
    using CleanArchitecture.Domain.UnitTests.Models.Specifications;
    using FluentAssertions;

    public class SpecificationTests
    {

        [Fact]
        public void IsSatisfiedBy_WithTrueSpecification_ReturnsTrue()
        {
            var spec = new TrueSpecification();
            spec.IsSatisfiedBy(new object()).Should().BeTrue();
        }

        [Fact]
        public void IsSatisfiedBy_WithFalseSpecification_ReturnsFalse()
        {
            var spec = new FalseSpecification();
            spec.IsSatisfiedBy(new object()).Should().BeFalse();
        }

        [Fact]
        public void And_CombinesTwoTrueSpecifications_ReturnsTrue()
        {
            var spec1 = new TrueSpecification();
            var spec2 = new TrueSpecification();

            // Directly inspect the combined expression
            var combinedExpression = spec1.And(spec2).ToExpression();
            var compiled = combinedExpression.Compile();

            var result = compiled(new object());
            result.Should().BeTrue();
        }


        [Fact]
        public void And_CombinesTrueAndFalseSpecifications_ReturnsFalse()
        {
            var spec1 = new TrueSpecification();
            var spec2 = new FalseSpecification();
            var resultSpec = spec1.And(spec2);

            resultSpec.IsSatisfiedBy(new object()).Should().BeFalse();
        }

        [Fact]
        public void Or_CombinesTrueAndFalseSpecifications_ReturnsTrue()
        {
            var spec1 = new TrueSpecification();
            var spec2 = new FalseSpecification();
            var combinedExpression = spec1.Or(spec2).ToExpression();


            var compiled = combinedExpression.Compile();

            var result = compiled(new object());
            result.Should().BeTrue();
        }

        [Fact]
        public void Or_CombinesTwoFalseSpecifications_ReturnsFalse()
        {
            var spec1 = new FalseSpecification();
            var spec2 = new FalseSpecification();
            var resultSpec = spec1.Or(spec2);

            var combinedExpression = spec1.And(spec2).ToExpression();
            var compiled = combinedExpression.Compile();

            var result = compiled(new object());
            result.Should().BeFalse();
        }


    }
}
