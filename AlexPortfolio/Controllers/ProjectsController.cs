using AlexPortfolio.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class ProjectsController : Controller
    {
        #region Public Methods

        [HttpGet]
        public ActionResult Projects()
        {
            var projects = new ProjectsViewModel(MenuType.Projects, Request.IsAuthenticated, HttpContext.User);

            var project1 = new ProjectViewModel()
            {
                ProjectId = 0,
                Title = "Portfolio",
                Picture = "Projects/Portfolio/portfolio-logo.png"
            };

            var project2 = new ProjectViewModel()
            {
                ProjectId = 1,
                Title = "VA",
                Picture = "Projects/VA/va-logo.jpg"
            };

            projects.Projects.Add(project1);
            projects.Projects.Add(project2);

            return View(projects);
        }

        [HttpGet]
        public ActionResult ProjectDetails(int projectId)
        {
            var projectDetails = new ProjectDetailsViewModel(MenuType.Projects, Request.IsAuthenticated, HttpContext.User);

            switch (projectId)
            {
                case 0:
                    projectDetails.ProjectName = "Portfolio";
                    projectDetails.Stack = "C#; .NET; ASP.NET MVC; HTML; CSS; JavaScript; jQuery; AJAX; MS SQL Server; LINQ to SQL";
                    projectDetails.ProjectDescription = "I have been always curious about web-programming; so, I have decided to start my journey by creating a small portfolio web-page. This portfolio is implemented on C# programming language using ASP.NET framework to maintain the MVC design pattern. I enjoyed working on it and I have got a lot from it. Follow the link below to check the source code.";
                    projectDetails.ProjectUrlText = "Protfolio Repository";
                    projectDetails.ProjectUrl = "https://github.com/AlexEgorchatov/AlexPortfolio";
                    projectDetails.Pictures = new List<string>();

                    return View(projectDetails);

                case 1:
                    projectDetails.ProjectName = "VA";
                    projectDetails.Stack = "C#; .NET; MVVM; WPF";
                    projectDetails.ProjectDescription = "Back in school I really enjoyed the Advanced Algorithms course. How different algorithms work and how they can be used to optimize the computation speed fascinates my mind. As a result, I decided to write a program that visualizes different algorithms. I created a desktop application using the C# programming language WPF UI framework in order to maintain my skills in desktop development. The scope of the program is relatively small, it has only several algorithms, but in the future, I plan to make a website with a greater number of algorithms and many additional features. Follow the link below to check the source code.";
                    projectDetails.ProjectUrlText = "VA Repository";
                    projectDetails.ProjectUrl = "https://github.com/AlexEgorchatov/VARepo";
                    projectDetails.Pictures = new List<string>()
                    {
                        "Projects/VA/va-main.png",
                        "Projects/VA/va-sort.png",
                        "Projects/VA/va-string.png",
                        "Projects/VA/va-grid.png",
                    };

                    return View(projectDetails);

                default:
                    return View(projectDetails);
            }
        }

        #endregion
    }
}