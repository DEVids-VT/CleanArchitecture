namespace CleanArchitecture.Domain.UnitTests.Models.ValueObjects
{
    public class ComplexValueObject : SimpleValueObject
    {
        private DateTime dateTimeValue;

        public ComplexValueObject(int intValue, string stringValue, DateTime dateTimeValue)
            : base(intValue, stringValue)
        {
            this.dateTimeValue = dateTimeValue;
        }
    }
}
