using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class HobbiesViewModel : MasterViewModel
    {
        public List<HobbyViewModel> Hobbies { get; set; }

        public HobbiesViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
            Hobbies = new List<HobbyViewModel>();
        }
    }
}