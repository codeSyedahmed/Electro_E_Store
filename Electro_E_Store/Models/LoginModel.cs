using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Electro_E_Store.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter your email.")]
        public string admin_email { get; set; }
        [Required(ErrorMessage = "Please enter your password.")]
        public string a_password { get; set; }
    }
}