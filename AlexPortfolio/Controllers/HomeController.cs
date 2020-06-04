using AlexPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AlexPortfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MasterViewModel(MenuType.Index, Request.IsAuthenticated, HttpContext.User));
        }

        [HttpGet]
        public ActionResult About()
        {
            return View(new MasterViewModel(MenuType.About, Request.IsAuthenticated, HttpContext.User));
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View(new MasterViewModel(MenuType.Contact, Request.IsAuthenticated, HttpContext.User));
        }
    }
}