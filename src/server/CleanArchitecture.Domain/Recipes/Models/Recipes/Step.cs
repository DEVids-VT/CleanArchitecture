namespace CleanArchitecture.Domain.Recipes.Models.Recipes
{
    using CleanArchitecture.Domain.Common.Models;
    using CleanArchitecture.Domain.Recipes.Exceptions;
    using static ModelConstants.Step;
    public class Step : ValueObject
    {
        internal Step(string description, int order, string imageUrl = null)
        {
            this.Validate(description, order, imageUrl);

            this.Description = description;
            this.Order = order;
            this.ImageUrl = imageUrl;
        }
        public string Description { get; }
        public int Order { get; }
        public string? ImageUrl { get; }
        private void Validate(string desc, int quantity, string? imageUrl)
        {
            this.ValidateDesc(desc);
            this.ValidateOrder(quantity);
            this.ValidateImageUrl(imageUrl);
        }

        private void ValidateDesc(string name) =>
            Guard.ForStringLength<InvalidStepExcepion>(
                name,
                MinDescLength,
                MaxDescLength,
                nameof(this.Description));
        private void ValidateOrder(int order) =>
            Guard.AgainstOutOfRange<InvalidStepExcepion>(
                order,
                MinOrder,
                MaxOrder,
                nameof(this.Order));

        private void ValidateImageUrl(string? imageUrl)
        {
            if (imageUrl is null)
            {
                return;
            }
            Guard.ForValidUrl<InvalidStepExcepion>(
                imageUrl,
                nameof(this.ImageUrl));
        }
    }
}
