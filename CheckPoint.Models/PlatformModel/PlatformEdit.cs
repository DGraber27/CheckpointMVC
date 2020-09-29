using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Models.PlatformModel
{
    public class PlatformEdit
    {
        public int PlatformId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Manufacturor { get; set; }
        public DateTime ReleaseYear { get; set; }
    }
}
