using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GTT.Views.Models
{
    public class Message
    {
        [Required( ErrorMessage = "Invalid email address" )]
        [DataType( DataType.EmailAddress )]
        public string From { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}