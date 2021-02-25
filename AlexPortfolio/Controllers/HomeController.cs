using AlexPortfolio.Data;
using AlexPortfolio.Models;
using Microsoft.Owin.BuilderProperties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Media.Imaging;

namespace AlexPortfolio.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var content = DBHelper.GetHomeContent();

            return View(new HomeViewModel(MenuType.Index, Request.IsAuthenticated, HttpContext.User)
            {
                Greeting = content.Greeting,
                Intro = content.Intro,
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> UpdateHome(HomeContentViewModel homeContent)
        {
            var content = DBHelper.UpdateHomeContent(homeContent);
            dynamic respond = new ExpandoObject();

            respond.result = "success";
            respond.greeting = content.Greeting;
            respond.intro = content.Intro;
            respond.error = "";

            return Json(JsonConvert.SerializeObject(respond));
        }

        [HttpGet]
        public ActionResult About()
        {
            List<string> desktop = new List<string>()
            {
                ".NET Framework",
                "C#",
                "WPF",
                "Entity Framework",
                "LINQ",
                "Model-View-ViewModel (MVVM)",
                "C++"
            };

            List<string> web = new List<string>()
            {
                "HTML5",
                "CSS3",
                "PHP",
                "ASP.NET",
                "Model-View-Controller (MVC)",
                "JavaScript",
                "jQuery",
                "Ajax",
                "Bootstrap",
            };

            List<string> other = new List<string>()
            {
                "Oracle SQL",
                "MS SQL Server",
                "Git",
                "Agile",
                "Object-Oriented Programming",
                "Visual Studio",
                "Microsoft Office",
                "Bilingual English/Russian"
            };

            return View(new AboutViewModel(MenuType.About, Request.IsAuthenticated, HttpContext.User)
            {
                Summary = "A computing science student from Vancouver Island University with two years of proven successful experience in software development. Recognized for performance excellence. Using .Net, WPF, Entity Framework, and MS SQL server developed and deployed the company’s inventory management system with 50.000+ items to replace an old EPDM solution.",
                FacebookLink = "https://www.facebook.com/profile.php?id=100000820661738",
                InstagramLink = "https://www.instagram.com/anotherfakesub/",
                LinkedInLink = "https://www.linkedin.com/in/alex-roch-686b7718a/",
                GitHubLink = "https://github.com/AlexEgorchatov",
                DesktopSkills = desktop,
                WebSkills = web,
                OtherSkills = other,
                ContactInfo = new List<Tuple<string, string>>()
                {
                    new Tuple<string, string>("Address", "387 Cariboo Drive, Nanaimo BC, Canada"),
                    new Tuple<string, string>("Phone", "1-250-618-67-78"),
                    new Tuple<string, string>("Email", "alex.exorchatov@gmail.com"),
                }
            });
        }

        //[HttpPost] FINISH LATER
        //[Authorize]
        //public async Task<JsonResult> UpdateAbout(AboutContentViewModel aboutContent)
        //{

        //}

        [HttpGet]
        public ActionResult Contact()
        {
            var content = DBHelper.GetContactContent();

            return View(new ContactViewModel(MenuType.Contact, Request.IsAuthenticated, HttpContext.User)
            {
                HeaderText = content.HeaderText,
                Phone = content.Phone,
                Email = content.Email
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<JsonResult> UpdateContact(ContactContentViewModel contactContent)
        {
            var content = DBHelper.UpdateContactContent(contactContent);
            dynamic respond = new ExpandoObject();

            respond.result = "success";
            respond.headerText = content.HeaderText;
            respond.phone = content.Phone;
            respond.email = content.Email;
            respond.error = "";

            return Json(JsonConvert.SerializeObject(respond));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> SendEmail(SendEmailViewModel email)
        {
            dynamic respond = new ExpandoObject();

            //try
            //{
            //    if (ModelState.IsValid)
            //    {
            //        var message = new MailMessage();
            //        message.To.Add(new MailAddress("alex.exorchatov@gmail.com"));
            //        message.From = new MailAddress("john.daylight.doen@gmail.com");
            //        message.Subject = email.Subject;
            //        message.Body = $"A new email from {email.Sender}\n" + "Message:\n\n" + email.Message;

            //        var credentials = new NetworkCredential(message.From.Address, "Ukjccbz8Cnhtkjr");

            //        SmtpClient client = new SmtpClient
            //        {
            //            Host = "smtp.gmail.com",
            //            Port = 587,
            //            //Credentials = credentials,
            //            UseDefaultCredentials = false,
            //            EnableSsl = true,
            //        };

            //        client.Credentials = credentials;
            //        client.Send(message);

            //        respond.result = "success";
            //        respond.error = "";

            //        return Json(JsonConvert.SerializeObject(respond));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    respond.result = "error";
            //    respond.error = ex.Message;
            //}

            try
            {
                if (ModelState.IsValid)
                {
                    var message = new MailMessage();
                    message.From = new MailAddress(email.Sender);
                    message.Subject = email.Subject;
                    message.Body = email.Message;

                    DBHelper.SendEmail(message);

                    respond.result = "success";
                    respond.error = "";
                }
            }
            catch(Exception ex)
            {
                respond.result = "error";
                respond.error = ex.Message;
            }

            return Json(JsonConvert.SerializeObject(respond));
        }
    }
}