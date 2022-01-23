using System;

namespace WhooberCore.Domain.Exceptions
{
    public class WhooberAppException : Exception
    {
        public WhooberAppException()
        {
        }

        public WhooberAppException(string message)
            : base(message)
        {
        }
    }
}