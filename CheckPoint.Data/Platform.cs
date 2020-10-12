using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Data
{
    public class Platform
    {
        [Key]
        public int PlatformId { get; set; }
        //[ForeignKey(nameof (Review))]
        //public int ReviewId { get; set; }
        //public virtual Review Review { get; set; }
        //[ForeignKey(nameof(Game))]
        //public int GameId { get; set; }
        //public virtual Game Game { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Manufacturor { get; set; }
        [Required]
        public DateTime ReleaseYear { get; set; }
        public double AverageStarRating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var rating in AllGameReviews)
                {
                    totalAverageRating += rating.StarRating;
                }

                return (AllGameReviews.Count > 0) ? Math.Round(totalAverageRating / AllGameReviews.Count) : 0;
            }
        }
        public virtual ICollection<Game> AllGames { get; set; } = new List<Game>();
        public ICollection<Review> AllGameReviews { get; set; } = new List<Review>();
    }
}
