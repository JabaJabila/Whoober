namespace WhooberCore.Domain.Tools
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