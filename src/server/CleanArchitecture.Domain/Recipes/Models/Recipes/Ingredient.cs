namespace CleanArchitecture.Domain.Recipes.Models.Recipes
{
    using CleanArchitecture.Domain.Common.Models;
    using CleanArchitecture.Domain.Recipes.Enums;
    using CleanArchitecture.Domain.Recipes.Exceptions;
    using static ModelConstants.Ingredient;

    public class Ingredient
    {
        internal Ingredient(string name, decimal quantity, Unit unit)
        {
            this.Validate(name, quantity);

            this.Name = name;
            this.Quantity = quantity;
            this.Unit = unit;
        }
        public string Name { get; }
        public decimal Quantity { get; }
        public Unit Unit { get; }

        private void Validate(string name, decimal quantity)
        {
            this.ValidateName(name);
            this.ValidateQuantity(quantity);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidIngredientException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateQuantity(decimal quantity) =>
            Guard.AgainstOutOfRange<InvalidIngredientException>(
                quantity,
                MinQuantity,
                MaxQuantity,
                nameof(this.Name));
    }
}
