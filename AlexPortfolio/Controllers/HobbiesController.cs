using AlexPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class HobbiesController : Controller
    {
        [HttpGet]
        public ActionResult Hobbies()
        {
            var hobbies = new HobbiesViewModel(MenuType.Hobbies, Request.IsAuthenticated, HttpContext.User);

            var hobby0 = new HobbyViewModel
            {
                HobbyId = 0,
                Picture = "Education/VIU/viu-logo.png",
                Titile = "Byking"
            };

            var hobby1 = new HobbyViewModel
            {
                HobbyId = 1,
                Picture = "Education/VIU/viu-logo.png",
                Titile = "Hiking"
            };

            var hobby2 = new HobbyViewModel
            {
                HobbyId = 2,
                Picture = "Education/VIU/viu-logo.png",
                Titile = "Acrobatics"
            };

            var hobby3 = new HobbyViewModel
            {
                HobbyId = 3,
                Picture = "Education/VIU/viu-logo.png",
                Titile = "German"
            };

            hobbies.Hobbies.Add(hobby0);
            hobbies.Hobbies.Add(hobby1);
            hobbies.Hobbies.Add(hobby2);
            hobbies.Hobbies.Add(hobby3);

            return View(hobbies);
        }

        [HttpGet]
        public ActionResult HobbyDetails(int hobbyId)
        {
            var hobbyDetails = new HobbyDetailsViewModel(MenuType.Hobbies, Request.IsAuthenticated, HttpContext.User);

            switch (hobbyId)
            {
                case 0:
                    hobbyDetails.Title = "Byking";
                    hobbyDetails.Description = "I do liek byking, yay!";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Work/Inuktun/main-screen.png",
                        "Work/Inuktun/bom-screen.png",
                        "Work/Inuktun/bom-edit.png",
                        "Work/Inuktun/bom-edit-comment.png",
                        "Work/Inuktun/bom-with-comment.png",
                        "Work/Inuktun/open-file.png",
                    };

                    return View(hobbyDetails);

                case 1:
                    hobbyDetails.Title = "Hiking";
                    hobbyDetails.Description = "I do liek hiking, yay!";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Work/Inuktun/main-screen.png",
                        "Work/Inuktun/bom-screen.png",
                        "Work/Inuktun/bom-edit.png",
                        "Work/Inuktun/bom-edit-comment.png",
                        "Work/Inuktun/bom-with-comment.png",
                        "Work/Inuktun/open-file.png",
                    };

                    return View(hobbyDetails);

                case 2:
                    hobbyDetails.Title = "Acrobatics";
                    hobbyDetails.Description = "I do liek acrobatics, yay!";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Work/Inuktun/main-screen.png",
                        "Work/Inuktun/bom-screen.png",
                        "Work/Inuktun/bom-edit.png",
                        "Work/Inuktun/bom-edit-comment.png",
                        "Work/Inuktun/bom-with-comment.png",
                        "Work/Inuktun/open-file.png",
                    };

                    return View(hobbyDetails);

                case 3:
                    hobbyDetails.Title = "German";
                    hobbyDetails.Description = "I do liek German, yay!";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Work/Inuktun/main-screen.png",
                        "Work/Inuktun/bom-screen.png",
                        "Work/Inuktun/bom-edit.png",
                        "Work/Inuktun/bom-edit-comment.png",
                        "Work/Inuktun/bom-with-comment.png",
                        "Work/Inuktun/open-file.png",
                    };

                    return View(hobbyDetails);

                default:
                    return View(hobbyDetails);
            }
        }
    }
}