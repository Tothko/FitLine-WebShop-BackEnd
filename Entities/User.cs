using System;
using System.Collections.Generic;

namespace Entities
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Boolean isOrganization { get; set; }
        public Boolean IsAdmin { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order66> Orders { get; set; }
    }
}
