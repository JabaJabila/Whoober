namespace WhooberCore.Domain.Tools
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