using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.GameModels
{
    public class GameCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Platforms { get; set; }
        [Required]
        public string Developer { get; set; }
        [Required]
        public ESRB ESRB { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
    }
}
