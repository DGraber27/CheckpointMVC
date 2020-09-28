using CheckPoint.Models.PlatformModel;
using CheckPoint.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.GameModels
{
    public enum ESRB { eC, E, E10, T, M, AO, RP, KA }
    public class GameListItem
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Platforms { get; set; }
        public string Developer { get; set; }
        public ESRB ESRB { get; set; }
        public DateTime ReleaseDate { get { return DateTime.Now; } set { } }
        //public List<PlatformDetail> AllPlatforms {get; set;}
        public List<ReviewDetail> AllGameReviews { get; set; }
    }
}
