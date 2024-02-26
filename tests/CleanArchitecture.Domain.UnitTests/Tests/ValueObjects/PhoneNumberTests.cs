using CleanArchitecture.Domain.Content.Exceptions;
using CleanArchitecture.Domain.Content.Models.Profiles;
using FluentAssertions;

namespace CleanArchitecture.Domain.UnitTests.Tests.ValueObjects
{
    public class PhoneNumberTests
    {
        [Theory]
        [InlineData("+1234567890")]
        [InlineData("+123456789012345")]
        public void Constructor_ShouldNotThrow_ForValidPhoneNumber(string validPhoneNumber)
        {
            // Act
            var action = () => new PhoneNumber(validPhoneNumber);

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("+abcdefg")]
        [InlineData("+1234 567 890")]
        [InlineData("+1234-567-890")]
        public void Constructor_ShouldThrowInvalidPhoneNumberException_ForInvalidFormat(string invalidPhoneNumber)
        {
            // Act
            var action = () => new PhoneNumber(invalidPhoneNumber);

            // Assert
            action.Should().Throw<InvalidPhoneNumberException>()
                .WithMessage("Phone number must start with a '+' and contain only digits afterwards.");
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidPhoneNumberException_ForPhoneNumberTooShort()
        {
            // Arrange
            var tooShortPhoneNumber = "+123"; // Adjust based on MinPhoneNumberLength

            // Act
            var action = () => new PhoneNumber(tooShortPhoneNumber);

            // Assert
            action.Should().Throw<InvalidPhoneNumberException>()
                .WithMessage("*must have between*"); // Adjust the message based on your actual error message
        }

        [Fact]
        public void Constructor_ShouldThrowInvalidPhoneNumberException_ForPhoneNumberTooLong()
        {
            // Arrange
            var tooLongPhoneNumber = "+12345678901234567890"; // Adjust based on MaxPhoneNumberLength

            // Act
            var action = () => new PhoneNumber(tooLongPhoneNumber);

            // Assert
            action.Should().Throw<InvalidPhoneNumberException>()
                .WithMessage("*must have between*"); // Adjust the message based on your actual error message
        }

    }

}
