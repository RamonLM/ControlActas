using ControlActas.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public User Requestor { get; set; }
        public Provider Provider { get; set; }
        public DateTime Ordered { get; set; }
        public DateTime Received { get; set; }
        public double Price { get; set; }
    }
}
