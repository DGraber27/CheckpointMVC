using System;
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
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double StarRating { get; set; }
        [Display(Name = "Review Posted")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
