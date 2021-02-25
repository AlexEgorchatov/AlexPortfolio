using System.Collections.Generic;
using System.Security.Principal;

namespace AlexPortfolio.Models
{
    public class ProjectsViewModel : MasterViewModel
    {
        public List<ProjectViewModel> Projects { get; set; }

        #region Public Constructors

        public ProjectsViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
            Projects = new List<ProjectViewModel>();
        }

        #endregion
    }
}