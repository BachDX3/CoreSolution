using Application.Utility.Validation;
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
        [Display(Name ="User name")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [Display(Name ="Password")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        [Display(Name ="First name")]
        public string FirstName { get; set; }= string.Empty;
        [Required]
        [MaxLength(100)]
        [Display(Name ="Last name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(256)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        [MaxLength]
        [Display(Name = "ConcurrencyStamp")]
        public string ConcurrencyStamp { get; set; } = string.Empty;
        [Display(Name = "Phone number")]
        [PhoneNumberArttibute(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; } 
    }
}
