using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Data
{
    public enum ESRB { eC, E, E10, T, M, AO, RP, KA }
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        //[ForeignKey(nameof (Review))]
        //public int ReviewId { get; set; }
        //public virtual Review Review { get; set; }
        //[ForeignKey(nameof(Platform))]
        //public int PlatformId { get; set; }
        //public virtual Platform Platform { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Platforms { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public ESRB ESRB { get; set; }
      
        public virtual ICollection<Review> AllGameReviews { get; set; } = new List<Review>();
    }
}
