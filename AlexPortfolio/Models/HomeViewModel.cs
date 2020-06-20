using System.Security.Principal;

namespace AlexPortfolio.Models
{
    public class HomeViewModel : MasterViewModel
    {
        public string Greeting { get; set; }

        public string Intro { get; set; }

        public HomeViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {

        }
    }
}