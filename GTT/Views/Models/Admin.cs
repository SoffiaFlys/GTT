using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTT.Views.Models
{
    public class Admin
    {

        [Required(ErrorMessage = "password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}