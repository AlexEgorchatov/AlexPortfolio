using AlexPortfolio.Data;
using AlexPortfolio.Models;
using Newtonsoft.Json;
using System;
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
            return View(new MasterViewModel(MenuType.About, Request.IsAuthenticated, HttpContext.User));
        }

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
        [Authorize]
        public async Task<JsonResult> SendEmail(SendEmailViewModel email)
        {
            dynamic respond = new ExpandoObject();

            try
            {
                if (ModelState.IsValid)
                {
                    var message = new MailMessage();
                    message.To.Add(new MailAddress("alex.exorchatov@gmail.com"));
                    message.From = new MailAddress(email.Sender);
                    message.Subject = email.Subject;
                    message.Body = email.Message;

                    var credentials = new NetworkCredential(message.From.Address, "Ukjccbz*Cnhtkjr");

                    SmtpClient client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        Credentials = credentials
                    };

                    client.Send(message);

                    respond.result = "success";
                    respond.error = "";

                    return Json(JsonConvert.SerializeObject(respond));
                }
            }
            catch (Exception ex)
            {
                respond.result = "error";
                respond.error = ex.Message;
            }

            return Json(JsonConvert.SerializeObject(respond));
        }
    }
}