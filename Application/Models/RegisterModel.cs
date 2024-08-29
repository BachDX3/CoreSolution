using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(256)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }= string.Empty;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(256)]
        public string Email { get; set; } = string.Empty;
        [MaxLength]
        public string SecurityStamp { get; set; } = string.Empty;
        [MaxLength]
        public string ConcurrencyStamp { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
