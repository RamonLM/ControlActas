using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlActas.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
