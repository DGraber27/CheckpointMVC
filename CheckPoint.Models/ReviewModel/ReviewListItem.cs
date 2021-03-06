﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.ReviewModel
{
    public class ReviewListItem
    {
        [Display(Name = "Review ID")]
        public int ReviewId { get; set; }
        [Display(Name = "Author")]
        public Guid OwnerId { get; set; }
        [Display(Name = "Game ")]
        public int GameId { get; set; }
        [Display(Name = "Game Title")]
        public string GameTitle { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "User Score")]
        public double StarRating { get; set; }
        [Display(Name = "Created")]
        public DateTime CreatedUtc { get; set; }
       
    }
}
