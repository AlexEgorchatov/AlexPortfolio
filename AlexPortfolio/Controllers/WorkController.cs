using AlexPortfolio.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace AlexPortfolio.Controllers
{
    public class WorkController : Controller
    {
        [HttpGet]
        public ActionResult Work()
        {
            var work = new WorkViewModel(MenuType.Work, Request.IsAuthenticated, HttpContext.User);

            var job1 = new JobViewModel
            {
                JobId = 0,
                Picture = "Work/Inuktun/inuktun-logo.png",
                Company = "Inuktun Services Ltd",
                Position = "Software Engineer"
            };

            var job2 = new JobViewModel
            {
                JobId = 1,
                Picture = "Work/CrystalCam/crystalcam-logo.png",
                Company = "Crystal Cam Imaging, Inc.",
                Position = "Cooperative Education Student"
            };

            work.Jobs.Add(job1);
            work.Jobs.Add(job2);

            return View(work);
        }

        [HttpGet]
        public ActionResult JobDetails(int jobId)
        {
            var jobDetails = new JobDetailsViewModel(MenuType.Work, Request.IsAuthenticated, HttpContext.User);

            switch (jobId)
            {
                case 0:
                    jobDetails.Company = "Inuktun Services Ltd";
                    jobDetails.CompanyLink = "(https://www.eddyfi.com/en)";
                    jobDetails.Position = "Software Engineer";
                    jobDetails.Type = "Full Time/Part Time";
                    jobDetails.StartDate = "2018 May";
                    jobDetails.CompletionDate = "2019 September";
                    jobDetails.Duration = "1.5 years";
                    jobDetails.Address = "2569 Kenworth Rd, Nanaimo, BC Canada";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Designed and put into operation an application to meet specific requirements for the company's inventory management",
                        "Developed algorithms for fast acquisition and manipulating large data (more than 50.000 DB records at once)",
                        "Regularly consulted with customers on the project development status, new features, and software related issues"
                    };
                    jobDetails.PicturesDescription = "Unfortunately, because of Terms of Conduct, I cannot provide the source code of this application.";
                    jobDetails.Pictures = new List<string>()
                    {
                        "Work/Inuktun/main-screen.png",
                        "Work/Inuktun/bom-screen.png",
                        "Work/Inuktun/bom-edit.png",
                        "Work/Inuktun/bom-edit-comment.png",
                        "Work/Inuktun/bom-with-comment.png",
                        "Work/Inuktun/open-file.png",
                    };

                    return View(jobDetails);

                case 1:
                    jobDetails.Company = "Crystal Cam Imaging Inc.";
                    jobDetails.CompanyLink = "";
                    jobDetails.Position = "Cooperative Education Student";
                    jobDetails.Type = "Full Time";
                    jobDetails.StartDate = "2017 May";
                    jobDetails.CompletionDate = "2017 September";
                    jobDetails.Duration = "4 months";
                    jobDetails.Address = "2231 McGarrigle Rd, Nanaimo, BC Canada";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Found a solution for configuring WebRTC-based online-streaming video service",
                        "Redesigned the company's software UI by adding colour theme selection",
                        "Added the localization feature to the company's software to support multiple lagnuages"
                    };
                    jobDetails.PicturesDescription = "";
                    jobDetails.Pictures = new List<string>();

                    return View(jobDetails);

                default:
                    return View(jobDetails);
            }
        }
    }
}