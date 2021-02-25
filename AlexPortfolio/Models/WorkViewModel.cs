using System.Collections.Generic;
using System.Security.Principal;

namespace AlexPortfolio.Models
{
    public class WorkViewModel : MasterViewModel
    {
        #region Public Properties

        public List<JobViewModel> Jobs { get; set; }

        #endregion

        #region Public Constructors

        public WorkViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
            Jobs = new List<JobViewModel>();
        }

        #endregion
    }
}