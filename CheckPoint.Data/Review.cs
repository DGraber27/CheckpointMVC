using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public double StarRating { get; set; }
        public DateTime CreatedUtc { get; set; }
        public Guid AuthorId { get; set; }
        [ForeignKey(nameof (Game))]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        //[ForeignKey(nameof(Platform))]
        //public int PlatformId { get; set; }
        //public virtual Platform Platform { get; set; }

    }
}
