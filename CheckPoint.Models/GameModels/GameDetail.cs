using CheckPoint.Data;
using CheckPoint.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.GameModels
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PlatformID { get; set; }
        public string PlatTitle { get; set; }
        public string Developer { get; set; }
        public ESRB ESRB { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ReviewListItem> AllGameReviews { get; set; }
        [Display(Name = "Average User Score")]
        public double AverageStarRating
        {
            get
            {
                double totalAverageRating = 0;

                foreach (var starRating in AllGameReviews)
                {
                    totalAverageRating += starRating.StarRating;
                }

                return (AllGameReviews.Count > 0) ? Math.Round(totalAverageRating / AllGameReviews.Count) : 0;
            }
        }
        public byte[] GameImage { get; set; }

    }
}
