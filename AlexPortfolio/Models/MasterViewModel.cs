using AlexPortfolio.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AlexPortfolio.Models
{
    public class MasterViewModel
    {
        public bool IsAuthorized { get; private set; }

        public IPrincipal User { get; private set; }

        public List<MenuItemViewModel> Menu { get; }

        public MasterViewModel(MenuType menuType, bool isAuthorized, IPrincipal user)
        {
            IsAuthorized = isAuthorized;
            User = user;
            Menu = new List<MenuItemViewModel>()
            {
                new MenuItemViewModel(MenuType.Index, "/Home", "Home", false),
                new MenuItemViewModel(MenuType.About, "/Home/About", "About Me", false),
                new MenuItemViewModel(MenuType.Work, "#", "Work Experience", false),
                new MenuItemViewModel(MenuType.Education, "#", "Education", false),
                new MenuItemViewModel(MenuType.Projects, "#", "Projects", false),
                new MenuItemViewModel(MenuType.Hobbies, "#", "Hobbies", false),
                new MenuItemViewModel(MenuType.Contact, "/Home/Contact", "Contact Me", false),
            };

            Menu.First(i => i.MenuType == menuType).IsSelected = true;
        }
    }
}