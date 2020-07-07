using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class JobDetailsViewModel : MasterViewModel
    {
        public string Company { get; set; }

        public string Position { get; set; }

        public string Type { get; set; }

        public string Duration { get; set; }

        public string StartDate { get; set; }

        public string CompletionDate { get; set; }

        public string Address { get; set; }

        public List<string> DescriptionBulletPoints { get; set; }

        public List<Tuple<string, string, string>> Pictures { get; set; }

        public JobDetailsViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {

        }
    }
}