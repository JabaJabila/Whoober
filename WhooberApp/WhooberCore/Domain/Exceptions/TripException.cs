namespace WhooberCore.Domain.Exceptions
{
    public class TripException : WhooberAppException
    {
        public TripException()
        {
        }

        public TripException(string message)
            : base(message)
        {
        }
    }
}