using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    class Invoice

    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public List<int> StatusID { get; set; }
        public DateTime date { get; set; }
        public string details { get; set; }
    }
}
