using CheckPoint.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.ReviewModel
{
    public class ReviewCreate
    {
        [Required]
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name = "User Score")]
        public double StarRating { get; set; }
        [Display(Name = "Created")]
        public DateTime CreatedUtc { get; set; }
    }
}
