namespace CleanArchitecture.Domain.UnitTests
{
    using CleanArchitecture.Domain.UnitTests.Models.ValueObjects;
    using FluentAssertions;

    public class ValueObjectTests
    {
        [Fact]
        public void Equals_WithSameValues_ReturnsTrue()
        {
            var obj1 = new SimpleValueObject(1, "test");
            var obj2 = new SimpleValueObject(1, "test");

            obj1.Equals(obj2).Should().BeTrue();
        }

        [Fact]
        public void Equals_WithDifferentValues_ReturnsFalse()
        {
            var obj1 = new SimpleValueObject(1, "test");
            var obj2 = new SimpleValueObject(2, "test");

            obj1.Equals(obj2).Should().BeFalse();
        }

        [Fact]
        public void Equals_WithDerivedTypes_ReturnsFalse()
        {
            var baseObj = new SimpleValueObject(1, "test");
            var derivedObj = new ComplexValueObject(1, "test", DateTime.Now);

            baseObj.Equals(derivedObj).Should().BeFalse();
            derivedObj.Equals(baseObj).Should().BeFalse();
        }
        [Fact]
        public void GetHashCode_WithSameValues_ReturnsSameHashCode()
        {
            var obj1 = new SimpleValueObject(1, "test");
            var obj2 = new SimpleValueObject(1, "test");

            obj1.GetHashCode().Should().Be(obj2.GetHashCode());
        }

        [Fact]
        public void GetHashCode_WithDifferentValues_ReturnsDifferentHashCodes()
        {
            var obj1 = new SimpleValueObject(1, "test");
            var obj2 = new SimpleValueObject(2, "different");

            obj1.GetHashCode().Should().NotBe(obj2.GetHashCode());
        }
        [Fact]
        public void EqualityOperator_WithSameValues_ReturnsTrue()
        {
            var obj1 = new SimpleValueObject(1, "test");
            var obj2 = new SimpleValueObject(1, "test");

            (obj1 == obj2).Should().BeTrue();
        }

        [Fact]
        public void InequalityOperator_WithDifferentValues_ReturnsTrue()
        {
            var obj1 = new SimpleValueObject(1, "test");
            var obj2 = new SimpleValueObject(2, "test");

            (obj1 != obj2).Should().BeTrue();
        }
    }
}
