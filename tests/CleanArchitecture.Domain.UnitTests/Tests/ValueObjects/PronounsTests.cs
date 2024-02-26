using CleanArchitecture.Domain.Content.Exceptions;
using CleanArchitecture.Domain.Content.Models;
using CleanArchitecture.Domain.Content.Models.Profiles;
using FluentAssertions;

namespace CleanArchitecture.Domain.UnitTests.Tests.ValueObjects
{
    public class PronounsTests
    {
        [Theory]
        [InlineData("she/her")]
        [InlineData("they/them")]
        [InlineData("he/him")]
        public void Constructor_ShouldNotThrow_ForValidPronouns(string validPronouns)
        {
            // Act
            var action = () => new Pronouns(validPronouns);

            // Assert
            action.Should().NotThrow();
        }

        [Theory]
        [InlineData("she/")]
        [InlineData("/her")]
        [InlineData("123/456")]
        [InlineData("they-them")]
        public void Constructor_ShouldThrowInvalidPronounsException_ForInvalidFormat(string invalidPronouns)
        {
            // Act
            var action = () => new Pronouns(invalidPronouns);

            // Assert
            action.Should().Throw<InvalidPronounsException>();
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidPronounsException_ForPronounsTooShort()
        {
            // Arrange
            var tooShortPronouns = "a/b"; // Adjust based on MinPronounsLength

            // Act
            var action = () => new Pronouns(tooShortPronouns);

            // Assert
            action.Should().Throw<InvalidPronounsException>()
                .WithMessage("*must have between*"); // Adjust the message based on your actual error message
        }

        [Fact]
        public void Constructor_ShouldThrowInvalidPronounsException_ForPronounsTooLong()
        {
            // Arrange
            var tooLongPronouns = new string('a', ModelConstants.Pronouns.MaxPronounsLength + 1) + "/" + new string('b', ModelConstants.Pronouns.MaxPronounsLength + 1); // Adjust based on MaxPronounsLength

            // Act
            var action = () => new Pronouns(tooLongPronouns);

            // Assert
            action.Should().Throw<InvalidPronounsException>()
                .WithMessage("*must have between*"); // Adjust the message based on your actual error message
        }

    }

}
