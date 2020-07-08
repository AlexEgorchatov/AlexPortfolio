using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class EducationDetailsViewModel : MasterViewModel
    {
        public string University { get; set; }

        public string UniversityLink { get; set; }

        public string Program { get; set; }

        public string StartDate { get; set; }

        public string CompletionDate { get; set; }

        public List<string> Courses { get; set; }

        public EducationDetailsViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {

        }
    }
}