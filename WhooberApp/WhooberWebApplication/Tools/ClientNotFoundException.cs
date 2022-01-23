using System;

namespace Whoober_WebApplication.Tools
{
    public class ClientNotFoundException : Exception
    {
        public ClientNotFoundException(string message)
            : base(message)
        {
        }
    }
}