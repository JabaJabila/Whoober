using System.Diagnostics.CodeAnalysis;

namespace Whoober_WebApplication.Authentication
{
    public class Role
    {
        [NotNull]
        public static readonly Role Client = new Role("Client");

        [NotNull]
        public static readonly Role Driver = new Role("Driver");

        private Role(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}