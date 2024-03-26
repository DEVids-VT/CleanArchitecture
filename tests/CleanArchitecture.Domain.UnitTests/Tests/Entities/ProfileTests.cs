using CleanArchitecture.Domain.Recipes.Exceptions;
using CleanArchitecture.Domain.Recipes.Models;
using CleanArchitecture.Domain.Recipes.Models.Profiles;
using FluentAssertions;

namespace CleanArchitecture.Domain.UnitTests.Tests.Entities
{
    public class ProfileTests
    {
        [Fact]
        public void Constructor_ShouldCorrectlyInitializeProfile_WhenArgumentsAreValid()
        {
            // Arrange
            var validName = "John Doe";
            var validBio = "A short bio";
            var validImageUrl = "http://example.com/image.jpg";
            var validBirthDate = new DateTime(1990, 1, 1);
            var validPhoneNumber = "+359888888888"; // Adjust based on PhoneNumber format
            var validPronouns = "They/Them"; // Adjust based on Pronouns implementation

            // Act
            var profile = new Profile(validName, validBio, validImageUrl, validBirthDate, validPhoneNumber, validPronouns);

            // Assert
            profile.Name.Should().Be(validName);
            profile.Bio.Should().Be(validBio);
            profile.ImageUrl.Should().Be(validImageUrl);
            profile.BirthDate.Should().Be(validBirthDate);
            // Add assertions for PhoneNumber and Pronouns if they have public getters or other ways to validate
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidProfileException_ForInvalidNameLength()
        {
            // Arrange
            var invalidName = new string('a', ModelConstants.Profile.MaxNameLength + 1); // Assuming MaxNameLength is accessible
            var validBio = "A valid bio";
            var validImageUrl = "http://example.com/image.jpg";
            var validBirthDate = new DateTime(1990, 1, 1);
            var validPhoneNumber = "123-456-7890";
            var validPronouns = "He/Him";

            // Act
            var action = () => new Profile(invalidName, validBio, validImageUrl, validBirthDate, validPhoneNumber, validPronouns);

            // Assert
            action.Should().Throw<InvalidProfileException>()
                .WithMessage("*Name*");
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidProfileException_ForBioTooShort()
        {
            // Arrange
            var validName = "Jane Doe";
            var invalidBio = ""; // Assuming MinBioLength > 0
            var validImageUrl = "http://example.com/profile.jpg";
            var validBirthDate = new DateTime(1990, 1, 1);
            var validPhoneNumber = "123-456-7890";
            var validPronouns = "She/Her";

            // Act
            Action action = () => new Profile(validName, invalidBio, validImageUrl, validBirthDate, validPhoneNumber, validPronouns);

            // Assert
            action.Should().Throw<InvalidProfileException>()
                .WithMessage("*Bio*");
        }
        [Fact]
        public void Constructor_ShouldThrowInvalidProfileException_ForInvalidBirthDate()
        {
            // Arrange
            var validName = "John Doe";
            var validBio = "A short bio";
            var validImageUrl = "http://example.com/image.jpg";
            var invalidBirthDate = new DateTime(1800, 1, 1); // Assuming this is outside the allowed range
            var validPhoneNumber = "123-456-7890";
            var validPronouns = "He/Him";

            // Act
            var action = () => new Profile(validName, validBio, validImageUrl, invalidBirthDate, validPhoneNumber, validPronouns);

            // Assert
            action.Should().Throw<InvalidProfileException>()
                .WithMessage("*BirthDate*");
        }


    }
}
