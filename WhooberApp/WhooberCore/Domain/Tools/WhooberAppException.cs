using System;

namespace WhooberCore.Domain.Tools
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