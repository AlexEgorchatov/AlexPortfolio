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
                Picture = "Education/VIU/viu-logo.png",
                University = "Vancouver Island University",
                Program = "Computer Science"
            };

            var educationItem2 = new EducationItemViewModel
            {
                EducationId = 1,
                Picture = "Education/FESTU/festu-logo.png",
                University = "Far Eastern Transport State University",
                Program = "Information Technology"
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
                    educationDetails.Program = "Bachelor of Science: Computer Science";
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
                    educationDetails.UniversityLink = "http://en.dvgups.ru/";
                    educationDetails.Program = "Bachelor of Science: Information Technology";
                    educationDetails.StartDate = "2012";
                    educationDetails.CompletionDate = "2016";
                    educationDetails.Courses = new List<string>()
                    {
                        "Mathematical Modeling",
                        "Engineering and Computer Graphics",
                        "Electrical Engineering, Electronics, and Circuit Engineering",
                        "Programming",
                        "PC and Peripheral Devices",
                        "Operating Systems",
                        "Databases",
                        "Networks and Telecommunications",
                        "Data Protection",
                        "CAD Fundamentals",
                        "Applied Mechanics",
                        "Linguistic and Software Support to CAD Systems",
                        "Operation Theory Fundamentals",
                        "Artificial Intelligence Systems",
                        "CAD System Development",
                        "Digital Devices and Microprocessors",
                    };

                    return View(educationDetails);

                default:
                    return View(educationDetails);
            }
        }
    }
}