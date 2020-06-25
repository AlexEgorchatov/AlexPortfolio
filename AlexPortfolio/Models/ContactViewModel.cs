using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace AlexPortfolio.Models
{
    public class ContactViewModel : MasterViewModel
    {
        public string HeaderText { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ContactViewModel(MenuType menuType, bool isAuthorized, IPrincipal user) : base(menuType, isAuthorized, user)
        {

        }
    }
}