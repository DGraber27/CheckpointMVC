using CheckPoint.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.GameModels
{
   public class GameEdit
    {
        [Display(Name = "Game ID")]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Display(Name = "Platform")]
        public int PlatformID { get; set; }
        public string Developer { get; set; }
        [Display(Name = "Maturity Rating")]
        public ESRB ESRB { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public byte[] GameImage { get; set; }
    }
}
