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
          [ForeignKey(nameof(Game))]
        public int GameId { get; set; }
        public virtual Game Game {get; set;}
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Display(Name = "User Score")]
        public double StarRating { get; set; }
    }
}
