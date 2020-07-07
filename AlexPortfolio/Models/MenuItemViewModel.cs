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

        public string Icon { get; }

        public bool IsSelected { get; set; }

        public MenuItemViewModel(MenuType menuType)
        {
            MenuType = menuType;
            switch (MenuType)
            {
                case MenuType.Index:
                    Href = "/Home";
                    Title = "Home";
                    Icon = "fa fa-home fa-fw fa-lg";
                    break;

                case MenuType.About:
                    Href = "/Home/About";
                    Title = "About Me";
                    Icon = "fa fa-id-badge fa-fw fa-lg";
                    break;

                case MenuType.Work:
                    Href = "/Work/Work";
                    Title = "Work Experience";
                    Icon = "fa fa-briefcase fa-fw fa-lg";
                    break;

                case MenuType.Education:
                    Href = "/Education/Education";
                    Title = "Education";
                    Icon = "fa fa-graduation-cap fa-fw fa-lg";
                    break;

                case MenuType.Projects:
                    Href = "#";
                    Title = "Projects";
                    Icon = "fa fa-github-square fa-fw fa-lg";
                    break;

                case MenuType.Hobbies:
                    Href = "#";
                    Title = "Hobbies";
                    Icon = "fa fa-thumbs-up fa-fw fa-lg";
                    break;

                case MenuType.Contact:
                    Href = "/Home/Contact";
                    Title = "Contact Me";
                    Icon = "fa fa-envelope fa-fw fa-lg";
                    break;
            }
        }
    }
}