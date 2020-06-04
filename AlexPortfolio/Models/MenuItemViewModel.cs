using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AlexPortfolio.Models
{
    public class MenuItemViewModel
    {
        public MenuType MenuType { get; }

        public string Href { get; }

        public string Title { get; }

        public bool IsSelected { get; set; }

        public MenuItemViewModel(MenuType menuType, string href, string title, bool isSelected)
        {
            MenuType = menuType;
            Href = href;
            Title = title;
            IsSelected = isSelected;
        }
    }
}