namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainException : Exception
    {
        protected BaseDomainException()
        {
            
        }
        protected BaseDomainException(string error): base(error)
        {
            _error = error;
        }
        private string? _error;

        public string Error
        {
            get => _error ?? base.Message;
            set => _error = value;
        }
    }
}
