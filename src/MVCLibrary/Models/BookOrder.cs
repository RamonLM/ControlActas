using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.Models
{
    public class BookOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public User Requestor { get; set; }
        public Provider Provider { get; set; }
        public DateTime Ordered { get; set; }
        public DateTime Received { get; set; }
        public double Price { get; set; }
    }
}
