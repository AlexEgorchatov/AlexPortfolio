using AlexPortfolio.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AlexPortfolio.Controllers
{
    public class EducationController : Controller
    {
        [HttpGet]
        public ActionResult Education()
        {
            var education = new EducationViewModel(MenuType.Education, Request.IsAuthenticated, HttpContext.User);

            var educationItem1 = new EducationItemViewModel
            {
                EducationId = 0,
                Picture = "alex.jpg",
                University = "Vancouver Island University",
                Program = "Computer Science"
            };

            var educationItem2 = new EducationItemViewModel
            {
                EducationId = 1,
                Picture = "alex.jpg",
                University = "Far Eastern Transport State University",
                Program = "Computer Science"
            };

            education.EducationItems.Add(educationItem1);
            education.EducationItems.Add(educationItem2);

            return View(education);
        }

        [HttpGet]
        public ActionResult EducationDetails(int educationId)
        {
            var educationDetails = new EducationDetailsViewModel(MenuType.Education, Request.IsAuthenticated, HttpContext.User);

            switch (educationId)
            {
                case 0:
                    educationDetails.University = "Vancouver Island University";
                    educationDetails.UniversityLink = "http://www.viu.ca/";
                    educationDetails.Program = "Bachelor of Computer Science";
                    educationDetails.StartDate = "2017";
                    educationDetails.CompletionDate = "2020";
                    educationDetails.Courses = new List<string>()
                    {
                        "Computer Science I",
                        "Computer Science II",
                        "Topics in Computer Science",
                        "Systems and Networks",
                        "Data Structures",
                        "Computer Architecture and Assembly Language",
                        "Software Engineering",
                        "Web Programming",
                        "Foundations of Computer Science",
                        "Programming Languages",
                        "Digital Logic and Computer Organization",
                        "Intro to Operating Systems",
                        "Database Systems",
                        "Networks and Communications",
                    };

                    return View(educationDetails);

                case 1:
                    educationDetails.University = "Far Eastern Transport State University";
                    educationDetails.UniversityLink = "#";
                    educationDetails.Program = "Bachelor of Computer Science";
                    educationDetails.StartDate = "2012";
                    educationDetails.CompletionDate = "2016";
                    educationDetails.Courses = new List<string>()
                    {
                        "Computer Science I",
                        "Computer Science II",
                        "Topics in Computer Science",
                        "Systems and Networks",
                        "Data Structures",
                        "Computer Architecture and Assembly Language",
                        "Software Engineering",
                        "Web Programming",
                        "Foundations of Computer Science",
                        "Programming Languages",
                        "Digital Logic and Computer Organization",
                        "Intro to Operating Systems",
                        "Database Systems",
                        "Networks and Communications",
                    };

                    return View(educationDetails);

                default:
                    return View(educationDetails);
            }
        }
    }
}