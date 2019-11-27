using System;

namespace Entities
{
    public class Address
    {
        public int id { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string Floor { get; set; }
    }
}
