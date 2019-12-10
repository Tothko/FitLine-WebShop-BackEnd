using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Address> Addresses { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
    }
}
