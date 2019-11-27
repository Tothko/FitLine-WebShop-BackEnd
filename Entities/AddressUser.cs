using System;

namespace Entities
{
    public class AddressUser
    {
        public int AddressID { get; set; }
        public  Address Address { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
    }
}
