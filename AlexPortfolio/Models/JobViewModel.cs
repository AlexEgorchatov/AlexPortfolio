using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexPortfolio.Models
{
    public class JobViewModel
    {
        public int JobId { get; set; }

        public string Picture { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }

        public JobViewModel()
        {

        }
    }
}