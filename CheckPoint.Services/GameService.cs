using CheckPoint.Data;
using CheckPoint.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
