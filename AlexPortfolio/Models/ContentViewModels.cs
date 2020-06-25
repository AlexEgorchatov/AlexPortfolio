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
}