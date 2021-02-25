using System.Collections.Generic;
using System.Security.Principal;

namespace AlexPortfolio.Models
{
    public class JobDetailsViewModel : MasterViewModel
    {
        #region Public Properties

        public string Address { get; set; }

        public string Company { get; set; }

        public string CompanyLink { get; set; }

        public string CompletionDate { get; set; }

        public List<string> DescriptionBulletPoints { get; set; }

        public string Duration { get; set; }

        public List<string> Pictures { get; set; }

        public string PicturesDescription { get; set; }

        public string Position { get; set; }

        public string StartDate { get; set; }

        public string Type { get; set; }

        #endregion

        #region Public Constructors

        public JobDetailsViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {
        }

        #endregion
    }
}