using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CleanArchitecture.Domain.UnitTests")]
namespace CleanArchitecture.Domain.Recipes.Models.Authors
{
    using CleanArchitecture.Domain.Common;
    using CleanArchitecture.Domain.Common.Models;
    using CleanArchitecture.Domain.Recipes.Exceptions;
    using static ModelConstants.Profile;

    internal class Profile : Entity<Guid>, IAggregateRoot
    {
        internal Profile(string name, string bio, string imageUrl, DateTime birthDate, string phoneNumber, string pronouns)
        {
            this.Validate(name, bio, imageUrl, birthDate);

            this.Name = name;
            this.Bio = bio;
            this.ImageUrl = imageUrl;
            this.BirthDate = birthDate;
            this.PhoneNumber = phoneNumber;
            this.Pronouns = pronouns;
        }

        public string Name { get; private set; }
        public string Bio { get; private set; }
        public string ImageUrl { get; private set; }
        public DateTime BirthDate { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Pronouns Pronouns { get; private set; }

        private void Validate(string name, string bio, string imageUrl, DateTime birthDate)
        {
            this.ValidateName(name);
            this.ValidateBio(bio);
            this.ValidateImageUrl(imageUrl);
            this.ValidateBirthDate(birthDate);
        }
        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidProfileException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateBio(string bio) =>
            Guard.ForStringLength<InvalidProfileException>(
                bio,
                MinBioLength,
                MaxBioLength,
                nameof(this.Bio));

        private void ValidateImageUrl(string imageUrl)
            => Guard.ForValidUrl<InvalidProfileException>(
                imageUrl,
                nameof(this.ImageUrl));

        private void ValidateBirthDate(DateTime birthDate) =>
            Guard.AgainstOutOfRange<InvalidProfileException>(
                birthDate,
                MinBirthDate,
                MaxBirthDate,
                nameof(this.BirthDate));

    }
}
