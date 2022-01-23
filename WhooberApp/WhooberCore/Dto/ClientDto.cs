using System;

namespace WhooberCore.Dto
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public Guid ClientIdInDb { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}