using CheckPoint.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CheckPoint.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [AllowHtml]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Platform")]
        public int PlatformID { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        [Display (Name = "Maturity Rating")]
        public ESRB ESRB { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Game Image")]
        public byte[] GameImage { get; set; }
    }
}
