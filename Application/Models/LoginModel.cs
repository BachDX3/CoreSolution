﻿using System;
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
        [Display(Name ="User name")]
        public string UserName { get; set; } 
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }  
    }
}
