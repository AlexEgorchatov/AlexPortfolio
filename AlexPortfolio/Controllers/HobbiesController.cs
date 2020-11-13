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
                Picture = "Hobby/Coding/Coding-logo.png",
                Titile = "Coding"
            };

            var hobby1 = new HobbyViewModel
            {
                HobbyId = 1,
                Picture = "Hobby/Acrobatics/Acro-logo.jpg",
                Titile = "Acrobatics"
            };

            var hobby2 = new HobbyViewModel
            {
                HobbyId = 2,
                Picture = "Hobby/Outdoor/Outdoor-logo.jpeg",
                Titile = "Outdoor Activities"
            };

            var hobby3 = new HobbyViewModel
            {
                HobbyId = 3,
                Picture = "Hobby/Snowboarding/Snowboard-logo.jpg",
                Titile = "Snowboarding"
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
                    hobbyDetails.Title = "Coding";
                    hobbyDetails.Description = "I believe that in order to keep the sharpness of mind, it is crucial to solve various logical puzzles. And the main reason why I love programming is that it is an infinite source of these puzzles: there will always be a problem which one can think about, write some code, and find an answer. I follow this preach by regularly challenging my problem-solving skills. To see some problems I solve and samples of my code, please check my HackerRank profile:";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Hobby/Coding/Coding1.png",
                        "Hobby/Coding/Coding2.png",
                        "Hobby/Coding/Coding3.png",
                    };

                    return View(hobbyDetails);

                case 1:
                    hobbyDetails.Title = "Acrobatics";
                    hobbyDetails.Description = "Besides programming, acrobatics is my biggest hobby. I started doing it when I was 7, and I did it for 15 years. Acrobatics is a team sport and since I moved to Canada, I was not able to engage it anymore. However, it does not mean that I forgot all of my skills. Even despite the fact that it has been four years since I officially stopped acrobatics, I am still able to perform one arm handstand, planche, press handstand, and other elements. I have a Master of Sports degree and I was twice a bronze winner of the Russian Championship.";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Hobby/Acrobatics/Acro1.jpg",
                        "Hobby/Acrobatics/Acro2.jpg",
                        "Hobby/Acrobatics/Acro3.jpg",
                        "Hobby/Acrobatics/Acro4.jpg",
                    };

                    return View(hobbyDetails);

                case 2:
                    hobbyDetails.Title = "Outdoor Activities";
                    hobbyDetails.Description = "I enjoy any type of outdoor activities, from climbing mountains to biking. Hiking helps me to relax after spending many hours in front of a computer screen. In addition, it is very important for health and good health makes a very positive impact on brain activity.";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Hobby/Outdoor/Outdoor1.jpg",
                        "Hobby/Outdoor/Outdoor2.jpg",
                        "Hobby/Outdoor/Outdoor3.jpg",
                        "Hobby/Outdoor/Outdoor4.jpg",
                    };

                    return View(hobbyDetails);

                case 3:
                    hobbyDetails.Title = "Snowboarding";
                    hobbyDetails.Description = "\"Just try new things. Don't be afraid\". Snowboarding is my most recent hobby. I tried snowboarding for the first time in December 2019 and immediately fell in love with that. If somebody wants to take a break from work and to think of nothing but speed, one should learn how to snowboard.";
                    hobbyDetails.Pictures = new List<string>()
                    {
                        "Hobby/Snowboarding/Snowboard1.jpg",
                        "Hobby/Snowboarding/Snowboard2.jpg",
                        "Hobby/Snowboarding/Snowboard3.jpg",
                    };

                    return View(hobbyDetails);

                default:
                    return View(hobbyDetails);
            }
        }
    }
}