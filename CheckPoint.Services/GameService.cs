using CheckPoint.Data;
using CheckPoint.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    
                    Title = model.Title,
                    Description = model.Description,
                    Platforms = model.Platforms,
                    Developer = model.Developer,
                    ESRB = (Data.ESRB)model.ESRB,
                    ReleaseDate = model.ReleaseDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Games
                    .Select(
                        e =>
                        new GameListItem
                        {
                            GameId = e.GameId,
                            Title = e.Title,
                            Description = e.Description,
                            Platforms = e.Platforms,
                            Developer = e.Developer,
                            ESRB = (Models.GameModels.ESRB)e.ESRB,
                            ReleaseDate = e.ReleaseDate
                        }
                        );
                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == id);
                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Platforms = entity.Platforms,
                        Developer = entity.Developer,
                        ESRB = (Models.GameModels.ESRB)entity.ESRB,
                        ReleaseDate = entity.ReleaseDate,
                        AverageStarRating =entity.AverageStarRating
                    };
            }
        }

        public bool UpdateGame (GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(e => e.GameId == model.GameId);
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Platforms = model.Platforms;
                entity.Developer = model.Developer;
                entity.ESRB = (Data.ESRB)model.ESRB;
                entity.ReleaseDate = model.ReleaseDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
