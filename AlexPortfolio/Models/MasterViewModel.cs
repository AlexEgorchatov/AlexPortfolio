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
                new MenuItemViewModel(MenuType.Index),
                new MenuItemViewModel(MenuType.About),
                new MenuItemViewModel(MenuType.Work),
                new MenuItemViewModel(MenuType.Education),
                //new MenuItemViewModel(MenuType.Projects),
                new MenuItemViewModel(MenuType.Hobbies),
                new MenuItemViewModel(MenuType.Contact),
            };

            Menu.First(i => i.MenuType == menuType).IsSelected = true;
        }
    }
}