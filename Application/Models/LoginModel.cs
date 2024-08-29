using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class LoginModel
    {
        [Required]
        [Range(1,100)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [Range(1, 50)]
        public string Password { get; set; } = string.Empty;
    }
}
