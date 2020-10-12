using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CheckPoint.Models.ReviewModel
{
    public class ReviewEdit
    {
        [Display(Name = "Review ID")]
        public int ReviewId { get; set; }
        [Required]
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        public virtual IEnumerable<SelectListItem> Game { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "User Score")]
        public double StarRating { get; set; }

    }
}
