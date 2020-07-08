using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexPortfolio.Models
{
    public class EducationItemViewModel
    {
        public int EducationId { get; set; }

        public string Picture { get; set; }

        public string University { get; set; }

        public string Program { get; set; }

        public EducationItemViewModel()
        {

        }
    }
}