using CheckPoint.Data;
using CheckPoint.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CheckPoint.Services
{
    //public class GameImageService
    //{
    //    private readonly Guid _userId;
    //    private readonly ApplicationDbContext _db = new ApplicationDbContext();


    //    public GameImageService(Guid userId)
    //    {
    //        _userId = userId;
    //    }
    //    public bool CreateGameImage(GameImageListItems model)
    //    {
            
    //        var entity =
    //            new GameImage()
    //            {
                    
    //                GameID = model.GameId,
    //                FileName = model.FileName,
    //                    FileContent = model.FileContent,
    //                FileType = model.FileType,
    //                FileSize = model.FileSize,

                    
    //            };

    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            ctx.GameImages.Add(entity);
    //            return ctx.SaveChanges() == 1;
    //        }
    //    }

    //    public IEnumerable<GameImageListItems> GetGameImages()
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var query =
    //                ctx
    //                .GameImages.ToList()
    //                .Select(
    //                    e =>
    //                    new GameImageListItems
    //                    {
    //                        GameImageId = e.GameImageID,
    //                        GameId = e.GameID,
    //                        FileName = e.FileName,
    //                        FileContent = e.FileContent,
    //                        FileType = e.FileType,
    //                        FileSize = e.FileSize,
                           
    //                    }
    //                    );
    //            var gameimages = query.ToArray();
    //            return gameimages;
    //        }
    //    }
    //    public GameImageListItems GetGameImageById(int id)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .GameImages
    //                    .SingleOrDefault(e => e.GameImageID == id);
    //            var detail = new GameImageListItems
    //            {
    //                GameImageId = entity.GameImageID,
    //                GameId = entity.GameID,
    //                FileName = entity.FileName,
    //                FileContent = entity.FileContent,
    //                FileType = entity.FileType,
    //                FileSize = entity.FileSize
                   
    //            };
    //            return detail;
             
    //        }
    //    }

    //    public bool UpdateGameImage(GameImageListItems model)
    //    {
    //        //model.GameImage = ConvertToBytes(file);
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                .GameImages
    //                .Single(e => e.GameImageID == model.GameImageId);
    //            entity.FileName = model.FileName;
    //            entity.FileContent = model.FileContent;
    //            entity.FileType = model.FileType;
    //            entity.FileSize = model.FileSize;

    //            return ctx.SaveChanges() == 1;
    //        }
    //    }

    //    public bool DeleteGameImage(int gameImageId)
    //    {
    //        using (var ctx = new ApplicationDbContext())
    //        {
    //            var entity =
    //                ctx
    //                    .GameImages
    //                    .Single(e => e.GameImageID == gameImageId);

    //            ctx.GameImages.Remove(entity);

    //            return ctx.SaveChanges() == 1;
    //        }
    //    }
    //}
}
