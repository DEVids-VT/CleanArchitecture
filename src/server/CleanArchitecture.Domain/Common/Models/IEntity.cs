namespace CleanArchitecture.Domain.Common.Models
{
    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
