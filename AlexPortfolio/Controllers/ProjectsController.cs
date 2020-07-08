using AlexPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: Projects
        public ActionResult Projects()
        {
            return View(new MasterViewModel(MenuType.Projects, Request.IsAuthenticated, HttpContext.User));
        }
    }
}