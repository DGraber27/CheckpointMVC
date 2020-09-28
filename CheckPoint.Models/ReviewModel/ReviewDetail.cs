using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.ReviewModel
{
    public class ReviewDetail
    {
        public int ReviewId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display (Name = "User Score")]
        public double StarRating { get; set; }
        [Display(Name = "Review Posted")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
