using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class WorkViewModel : MasterViewModel
    {
        public List<JobViewModel> Jobs { get; set; }

        public WorkViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
            Jobs = new List<JobViewModel>();
        }
    }
}