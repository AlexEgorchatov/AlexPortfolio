using AlexPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class WorkController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new MasterViewModel(MenuType.Index, Request.IsAuthenticated, HttpContext.User)
            {

            });
        }
    }
}