using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class EducationViewModel : MasterViewModel
    {
        public List<EducationItemViewModel> EducationItems { get; set; }

        public EducationViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
            EducationItems = new List<EducationItemViewModel>();
        }
    }
}