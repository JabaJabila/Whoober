namespace WhooberCore.Domain.Exceptions
{
    public class RatingException : WhooberAppException
    {
        public RatingException()
        {
        }

        public RatingException(string message)
            : base(message)
        {
        }
    }
}