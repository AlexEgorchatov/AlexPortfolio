using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class HobbyDetailsViewModel : MasterViewModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Pictures { get; set; }

        public HobbyDetailsViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {

        }
    }
}