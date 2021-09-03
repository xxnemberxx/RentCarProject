using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class UserForRegisterDto : IDto
    {
        public long CitizenId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobilePhones { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
