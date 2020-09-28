using CheckPoint.Models.GameModels;
using CheckPoint.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.PlatformModel
{
    public class PlatformListItem
    {
        public int PlatformId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manufacturor { get; set; }
        public DateTime ReleaseYear { get { return DateTime.Now; } set { } }
        [Display(Name = "Average User Score")]
        public double AverageStarRating { get; }
        public List<ReviewDetail> AllReviews { get; set; }
        public List<GameDetail> AllGames {get; set; }
    }
}
