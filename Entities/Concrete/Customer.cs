using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public string NationalityId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
