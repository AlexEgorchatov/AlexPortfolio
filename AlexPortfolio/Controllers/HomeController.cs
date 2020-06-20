using AlexPortfolio.Models;
using Newtonsoft.Json;
using System.Dynamic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            string greeting = "Hi, I am Alex";
            string intro = "Recent grad from VIU";

            return View(new HomeViewModel(MenuType.Index, Request.IsAuthenticated, HttpContext.User) 
            { 
                Greeting = greeting,
                Intro = intro
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> UpdateHome(HomeContentViewModel homeContent)
        {
            dynamic respond = new ExpandoObject();

            respond.result = "success";
            respond.greeting = homeContent.Greeting;
            respond.intro = homeContent.Intro;
            respond.error = "";

            return Json(JsonConvert.SerializeObject(respond));
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