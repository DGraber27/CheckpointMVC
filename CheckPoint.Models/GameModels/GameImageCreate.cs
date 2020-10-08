using CheckPoint.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CheckPoint.Models.GameModels
{
   public class GameImageCreate
    {
        public int GameId { get; set; }
        [Required]
        public HttpPostedFileBase[] Files { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string  FileType { get; set; }
        public long FileSize { get; set; }

        public GameImageCreate() { }

        public GameImageCreate(int id)
        {
            GameId = id;
        }

        public IEnumerable<GameImage> MapToModel()
        {
            var result = new List<GameImage>();
            for (int i = 0; i < Files.Length; i++)
            {
                BinaryReader b = new BinaryReader(Files[i].InputStream);
                byte[] content = b.ReadBytes(Files[i].ContentLength);
                result.Add(new GameImage()
                {
                    GameImageID = 0,
                    GameID = GameId,
                    FileContent = content,
                    FileName = Files[i].FileName,
                    FileType = Files[i].ContentType,
                    FileSize = Files[i].ContentLength

                });
            }
            return result;
        }
    }
}
