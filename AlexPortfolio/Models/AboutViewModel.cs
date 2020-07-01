using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class AboutViewModel : MasterViewModel
    {
        public string Summary { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public string LinkedInLink { get; set; }

        public string GitHubLink { get; set; }

        public List<string> DesktopSkills { get; set; }

        public List<string> WebSkills { get; set; }

        public List<string> OtherSkills { get; set; }

        public List<Tuple<string, string>> ContactInfo { get; set; }

        public AboutViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {

        }
    }
}