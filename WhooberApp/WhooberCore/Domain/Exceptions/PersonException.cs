namespace WhooberCore.Domain.Exceptions
{
    public class PersonException : WhooberAppException
    {
        public PersonException()
        {
        }

        public PersonException(string message)
            : base(message)
        {
        }
    }
}