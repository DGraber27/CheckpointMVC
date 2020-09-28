using System;
using System.Collections.Generic;
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
        public string Platforms { get; set; }
        public string Developer { get; set; }
        public ESRB ESRB { get; set; }
        public DateTime ReleaseDate { get { return DateTime.Now; } set { } }
    }
}
