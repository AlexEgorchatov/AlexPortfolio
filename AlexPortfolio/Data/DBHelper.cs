﻿using AlexPortfolio.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AlexPortfolio.Data
{
    public class DBHelper
    {
        private static HomeContentViewModel CreateHomeContent(HomeContentViewModel content)
        {
            try
            {
                using (var dc = new PortfolioDataContext())
                {
                    dc.PageContents.InsertOnSubmit(new PageContent()
                    {
                        ContentType = (int)MenuType.Index,
                        Content = JsonConvert.SerializeObject(content)
                    });
                    dc.SubmitChanges();

                    return content;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static HomeContentViewModel GetHomeContent()
        {
            try
            {
                using (var dc = new PortfolioDataContext())
                {
                    var homeContent = dc.PageContents.FirstOrDefault(i => i.ContentType == (int)MenuType.Index);

                    if (homeContent == null)
                    {
                        var content = new HomeContentViewModel()
                        {
                            Greeting = "Hi, I am Alex",
                            Intro = "Software Developer"
                        };

                        return CreateHomeContent(content);
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<HomeContentViewModel>(homeContent.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static HomeContentViewModel UpdateHomeContent(HomeContentViewModel content)
        {
            try
            {
                using (var dc = new PortfolioDataContext())
                {
                    var homeContent = dc.PageContents.FirstOrDefault(i => i.ContentType == (int)MenuType.Index);

                    if (homeContent == null)
                    {
                        return null;
                    }
                    else
                    {
                        homeContent.Content = JsonConvert.SerializeObject(content);
                        dc.SubmitChanges();
                        return content;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}