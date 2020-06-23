using AlexPortfolio.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AlexPortfolio.Data
{
    public class DBHelper
    {
        #region Home (Index)

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

        #endregion

        #region About

        #endregion

        #region Work

        #endregion

        #region Education

        #endregion

        #region Projects

        #endregion

        #region Hobbies

        #endregion

        #region Contact

        private static ContactContentViewModel CreateContactContent(ContactContentViewModel content)
        {
            try
            {
                using (var dc = new PortfolioDataContext())
                {
                    dc.PageContents.InsertOnSubmit(new PageContent()
                    {
                        ContentType = (int)MenuType.Contact,
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

        public static ContactContentViewModel GetContactContent()
        {
            try
            {
                using (var dc = new PortfolioDataContext())
                {
                    var contactContent = dc.PageContents.FirstOrDefault(i => i.ContentType == (int)MenuType.Contact);

                    if (contactContent == null)
                    {
                        var content = new ContactContentViewModel()
                        {
                            HeaderText = "Contact me by calling or send me an email using the form below",
                            Phone = "8-800-80-80",
                            Email = "email@email.com",
                        };

                        return CreateContactContent(content);
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<ContactContentViewModel>(contactContent.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static ContactContentViewModel UpdateContactContent(ContactContentViewModel content)
        {
            try
            {
                using (var dc = new PortfolioDataContext())
                {
                    var contactContent = dc.PageContents.FirstOrDefault(i => i.ContentType == (int)MenuType.Contact);

                    if (contactContent == null)
                    {
                        return null;
                    }
                    else
                    {
                        contactContent.Content = JsonConvert.SerializeObject(content);
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

        #endregion
    }
}