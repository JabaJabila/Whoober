using System;

namespace Whoober_WebApplication.Tools
{
    public class InvalidLoginException : Exception
    {
        public InvalidLoginException(string message)
        : base(message)
        {
        }
    }
}