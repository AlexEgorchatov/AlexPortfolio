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
        public ActionResult Work()
        {
            return View(new MasterViewModel(MenuType.Work, Request.IsAuthenticated, HttpContext.User)
            {

            });
        }

        public ActionResult JobDetails()
        {
            return View(new MasterViewModel(MenuType.Work, Request.IsAuthenticated, HttpContext.User)
            {

            });
        }
    }
}