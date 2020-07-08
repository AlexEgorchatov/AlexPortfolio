using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlexPortfolio.Models
{
    public class HomeContentViewModel
    {
        public string Greeting { get; set; }

        public string Intro { get; set; }
    }

    public class ContactContentViewModel
    {
        public string HeaderText { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }

    public class AboutContentViewModel
    {
        public string Summary { get; set; }

        public string FacebookLink { get; set; }

        public string InstagramLink { get; set; }

        public string LinkedInLink { get; set; }

        public string GitHubLink { get; set; }

        public List<string> DesktopSkills { get; set; }

        public List<string> WebSkills { get; set; }

        public List<string> OtherSkills { get; set; }

        public List<Tuple<string, string>> ContactInfo { get; set; }
    }

    public class WorkContentViewModel
    {
        public List<JobContentViewModel> Jobs { get; set; }

    }

    public class JobContentViewModel
    {
        public int JobId { get; set; }

        public string Picture { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }
    }

    public class JobDetailsContentViewModel
    {
        public string Company { get; set; }

        public string Position { get; set; }

        public string Type { get; set; }

        public string Duration { get; set; }

        public string StartDate { get; set; }

        public string CompletionDate { get; set; }

        public string Address { get; set; }

        public List<string> DescriptionBulletPoints { get; set; }

        public List<Tuple<string, string, string>> Pictures { get; set; }
    }

    public class EducationContentViewModel
    {
        public List<EducationItemContentViewModel> EducationItems {get; set;}
    }

    public class EducationItemContentViewModel
    {
        public int EducationId { get; set; }

        public string Picture { get; set; }

        public string University { get; set; }

        public string Program { get; set; }
    }

    public class EducationDetailsContentViewModel
    {
        public string University { get; set; }

        public string UniversityLink { get; set; }

        public string Program { get; set; }

        public string StartDate { get; set; }

        public string CompletionDate { get; set; }

        public List<string> Courses { get; set; }
    }
}