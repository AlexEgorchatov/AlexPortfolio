using AlexPortfolio.Models;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class EducationController : Controller
    {
        [HttpGet]
        public ActionResult Education()
        {
            return View(new MasterViewModel(MenuType.Education, Request.IsAuthenticated, HttpContext.User));
        }
    }
}