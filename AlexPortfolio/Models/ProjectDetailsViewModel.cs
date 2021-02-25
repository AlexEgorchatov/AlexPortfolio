using System.Collections.Generic;
using System.Security.Principal;

namespace AlexPortfolio.Models
{
    public class ProjectDetailsViewModel : MasterViewModel
    {
        #region Public Properties

        public List<string> Pictures { get; set; }

        public string ProjectDescription { get; set; }

        public string ProjectName { get; set; }

        public string ProjectUrl { get; set; }

        public string ProjectUrlText { get; set; }

        public string Stack { get; set; }

        #endregion

        #region Public Constructors

        public ProjectDetailsViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
        }

        #endregion
    }
}