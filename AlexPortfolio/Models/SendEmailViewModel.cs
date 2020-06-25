using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlexPortfolio.Models
{
    public class SendEmailViewModel
    {
        [Required]
        public string Sender { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
    }
}