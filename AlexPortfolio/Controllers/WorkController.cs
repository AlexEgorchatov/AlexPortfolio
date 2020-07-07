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
                Picture = "alex.jpg",
                Company = "Company 1",
                Position = "Position 1"
            };

            var job2 = new JobViewModel
            {
                JobId = 1,
                Picture = "alex.jpg",
                Company = "Company 2",
                Position = "Position 2"
            };

            var job3 = new JobViewModel
            {
                JobId = 2,
                Picture = "alex.jpg",
                Company = "Company 3",
                Position = "Position 3"
            };

            var job4 = new JobViewModel
            {
                JobId = 3,
                Picture = "alex.jpg",
                Company = "Company 4",
                Position = "Position 4"
            };

            var job5 = new JobViewModel
            {
                JobId = 4,
                Picture = "alex.jpg",
                Company = "Company 5",
                Position = "Position 5"
            };

            work.Jobs.Add(job1);
            work.Jobs.Add(job2);
            work.Jobs.Add(job3);
            work.Jobs.Add(job4);
            work.Jobs.Add(job5);

            return View(work);
        }

        [HttpGet]
        public ActionResult JobDetails(int jobId)
        {
            var jobDetails = new JobDetailsViewModel(MenuType.Work, Request.IsAuthenticated, HttpContext.User);

            switch (jobId)
            {
                case 0:
                    jobDetails.Company = "Company 1";
                    jobDetails.Position = "Position 1";
                    jobDetails.Type = "Full Time";
                    jobDetails.StartDate = "2010 April";
                    jobDetails.CompletionDate = "2012 May";
                    jobDetails.Duration = "2 years";
                    jobDetails.Address = "Address 1";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Did this",
                        "This",
                        "And This"
                    };
                    jobDetails.Pictures = new List<Tuple<string, string ,string>>()
                    {
                        new Tuple<string, string, string>("alex.jpg", "1st item", "It shows the first item"),
                        new Tuple<string, string, string>("alex.jpg", "2nd item", "It shows the second item"),
                        new Tuple<string, string, string>("alex.jpg", "3rd item", "It shows the third item"),
                    };

                    return View(jobDetails);

                case 1:
                    jobDetails.Company = "Company 2";
                    jobDetails.Position = "Position 2";
                    jobDetails.Type = "Full Time";
                    jobDetails.StartDate = "2010 April";
                    jobDetails.CompletionDate = "2012 May";
                    jobDetails.Duration = "2 years";
                    jobDetails.Address = "Address 2";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Did this",
                        "This",
                        "And This"
                    };
                    jobDetails.Pictures = new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>("alex.jpg", "1st item", "It shows the first item"),
                        new Tuple<string, string, string>("alex.jpg", "2nd item", "It shows the second item"),
                        new Tuple<string, string, string>("alex.jpg", "3rd item", "It shows the third item"),
                        new Tuple<string, string, string>("alex.jpg", "4th item", "It shows the fourth item"),
                    };

                    return View(jobDetails);

                case 2:
                    jobDetails.Company = "Company 3";
                    jobDetails.Position = "Position 3";
                    jobDetails.Type = "Full Time";
                    jobDetails.StartDate = "2010 April";
                    jobDetails.CompletionDate = "2012 May";
                    jobDetails.Duration = "2 years";
                    jobDetails.Address = "Address 3";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Did this",
                        "This",
                        "And This"
                    };
                    jobDetails.Pictures = new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>("alex.jpg", "1st item", "It shows the first item"),
                        new Tuple<string, string, string>("alex.jpg", "2nd item", "It shows the second item"),
                        new Tuple<string, string, string>("alex.jpg", "3rd item", "It shows the third item"),
                        new Tuple<string, string, string>("alex.jpg", "4th item", "It shows the fourth item"),
                    };

                    return View(jobDetails);

                case 3:
                    jobDetails.Company = "Company 4";
                    jobDetails.Position = "Position 4";
                    jobDetails.Type = "Part Time";
                    jobDetails.StartDate = "2010 April";
                    jobDetails.CompletionDate = "2012 May";
                    jobDetails.Duration = "2 years";
                    jobDetails.Address = "Address 4";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Did this",
                        "This",
                        "And This"
                    };
                    jobDetails.Pictures = new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>("alex.jpg", "1st item", "It shows the first item"),
                        new Tuple<string, string, string>("alex.jpg", "2nd item", "It shows the second item"),
                        new Tuple<string, string, string>("alex.jpg", "3rd item", "It shows the third item"),
                        new Tuple<string, string, string>("alex.jpg", "4th item", "It shows the fourth item"),
                        new Tuple<string, string, string>("alex.jpg", "5th item", "It shows the fifth item"),
                        new Tuple<string, string, string>("alex.jpg", "6th item", "It shows the sixth item"),
                    };

                    return View(jobDetails);

                case 4:
                    jobDetails.Company = "Company 5";
                    jobDetails.Position = "Position 5";
                    jobDetails.Type = "Part Time";
                    jobDetails.StartDate = "2010 April";
                    jobDetails.CompletionDate = "2012 May";
                    jobDetails.Duration = "2 years";
                    jobDetails.Address = "Address 5";
                    jobDetails.DescriptionBulletPoints = new List<string>()
                    {
                        "Did this",
                        "This",
                        "And This"
                    };
                    jobDetails.Pictures = new List<Tuple<string, string, string>>()
                    {
                        new Tuple<string, string, string>("alex.jpg", "1st item", "It shows the first item"),
                        new Tuple<string, string, string>("alex.jpg", "2nd item", "It shows the second item"),
                        new Tuple<string, string, string>("alex.jpg", "3rd item", "It shows the third item"),
                        new Tuple<string, string, string>("alex.jpg", "4th item", "It shows the fourth item"),
                        new Tuple<string, string, string>("alex.jpg", "5th item", "It shows the fifth item"),
                    };

                    return View(jobDetails);

                default:
                    return View(jobDetails);
            }
        }
    }
}