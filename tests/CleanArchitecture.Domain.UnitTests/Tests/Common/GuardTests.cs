using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common.Models;
using CleanArchitecture.Domain.Recipes.Models;
using CleanArchitecture.Domain.UnitTests.Models.Exceptions;
using FluentAssertions;

namespace CleanArchitecture.Domain.UnitTests.Tests.Common
{
    public class GuardTests
    {
        [Fact]
        public void AgainstEmptyString_ShouldNotThrow_WhenStringIsNotNullOrEmpty()
        {
            // Arrange
            var validString = "Valid String";

            // Act
            Action act = () => Guard.AgainstEmptyString<TestException>(validString);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void AgainstEmptyString_ShouldThrowTestException_WhenStringIsNull()
        {
            // Arrange
            string nullString = null;

            // Act
            Action act = () => Guard.AgainstEmptyString<TestException>(nullString);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*cannot be null or empty.");
        }

        [Fact]
        public void AgainstEmptyString_ShouldThrowTestException_WhenStringIsEmpty()
        {
            // Arrange
            var emptyString = "";

            // Act
            Action act = () => Guard.AgainstEmptyString<TestException>(emptyString);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*cannot be null or empty.");
        }

        [Theory]
        [InlineData("ValidLength", 5, 15)] // within range
        [InlineData("EdgeCaseLengths", 15, 15)] // exactly max length
        public void ForStringLength_ShouldNotThrow_WhenStringLengthIsWithinRange(string value, int minLength, int maxLength)
        {
            // Act
            Action act = () => Guard.ForStringLength<TestException>(value, minLength, maxLength);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ForStringLength_ShouldThrowTestException_WhenStringIsTooShort()
        {
            // Arrange
            var shortString = "Short";
            var minLength = 10;
            var maxLength = 20;

            // Act
            Action act = () => Guard.ForStringLength<TestException>(shortString, minLength, maxLength);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must have between 10 and 20 symbols.");
        }

        [Fact]
        public void ForStringLength_ShouldThrowTestException_WhenStringIsTooLong()
        {
            // Arrange
            var longString = new string('a', 25);
            var minLength = 5;
            var maxLength = 20;

            // Act
            Action act = () => Guard.ForStringLength<TestException>(longString, minLength, maxLength);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must have between 5 and 20 symbols.");
        }
        [Theory]
        [InlineData(5, 1, 10)]
        [InlineData(1, 1, 10)]
        [InlineData(10, 1, 10)]
        public void AgainstOutOfRange_ShouldNotThrow_WhenNumberIsWithinRange(int number, int min, int max)
        {
            // Act
            Action act = () => Guard.AgainstOutOfRange<TestException>(number, min, max);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void AgainstOutOfRange_ShouldThrowTestException_WhenNumberIsBelowRange()
        {
            // Arrange
            var number = 0;
            var min = 1;
            var max = 10;

            // Act
            Action act = () => Guard.AgainstOutOfRange<TestException>(number, min, max);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must be between 1 and 10.");
        }

        [Fact]
        public void AgainstOutOfRange_ShouldThrowTestException_WhenNumberIsAboveRange()
        {
            // Arrange
            var number = 11;
            var min = 1;
            var max = 10;

            // Act
            Action act = () => Guard.AgainstOutOfRange<TestException>(number, min, max);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must be between 1 and 10.");
        }

        [Fact]
        public void ForValidUrl_ShouldNotThrow_WhenUrlIsValid()
        {
            // Arrange
            var validUrl = "http://www.example.com";

            // Act
            Action act = () => Guard.ForValidUrl<TestException>(validUrl);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void ForValidUrl_ShouldThrowTestException_WhenUrlIsInvalid()
        {
            // Arrange
            var invalidUrl = "invalid_url";

            // Act
            Action act = () => Guard.ForValidUrl<TestException>(invalidUrl);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must be a valid URL.");
        }

        [Fact]
        public void ForValidUrl_ShouldThrowTestException_WhenUrlExceedsMaxLength()
        {
            // Arrange
            var longUrl = new string('a', ModelConstants.Common.MaxUrlLength + 1);

            // Act
            Action act = () => Guard.ForValidUrl<TestException>(longUrl);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must be a valid URL.");
        }

        [Fact]
        public void Against_ShouldNotThrow_WhenValuesAreNotEqual()
        {
            // Arrange
            var actualValue = "actual";
            var unexpectedValue = "unexpected";

            // Act
            Action act = () => Guard.Against<TestException>(actualValue, unexpectedValue);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        public void Against_ShouldThrowTestException_WhenValuesAreEqual()
        {
            // Arrange
            var actualValue = "value";
            var unexpectedValue = "value";

            // Act
            Action act = () => Guard.Against<TestException>(actualValue, unexpectedValue);

            // Assert
            act.Should().Throw<TestException>()
                .WithMessage("*must not be value.");
        }


    }
}
