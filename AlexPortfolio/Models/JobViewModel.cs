﻿namespace AlexPortfolio.Models
{
    public class JobViewModel
    {
        #region Public Properties

        public string Company { get; set; }

        public int JobId { get; set; }

        public string Picture { get; set; }

        public string Position { get; set; }

        #endregion

        #region Public Constructors

        public JobViewModel()
        {
        }

        #endregion
    }
}