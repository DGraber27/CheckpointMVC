using CheckPoint.Data;
using CheckPoint.Models.PlatformModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Services
{
    public class PlatformService
    {
        private readonly Guid _userId;

        public PlatformService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePlatform(PlatformCreate model)
        {
            var entity =
                new Platform()
                {

                    Title = model.Title,
                    Description = model.Description,
                    Manufacturor = model.Manufacturor,
                    ReleaseYear = model.ReleaseYear
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Platforms.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlatformListItem> GetPlatform()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Platforms
                    .Select(
                        e =>
                        new PlatformListItem
                        {
                            PlatformId = e.PlatformId,
                            Title = e.Title,
                            Description = e.Description,
                            Manufacturor = e.Manufacturor,
                            ReleaseYear = e.ReleaseYear
                        }
                        );
                return query.ToArray();
            }
        }

        public PlatformDetail GetPlatformById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Platforms
                        .Single(e => e.PlatformId == id);
                return
                    new PlatformDetail
                    {
                        PlatformId = entity.PlatformId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Manufacturor = entity.Manufacturor,
                        ReleaseYear = entity.ReleaseYear,
                    };
            }
        }

        public bool UpdatePlatform(PlatformEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Platforms
                    .Single(e => e.PlatformId == model.PlatformId);
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Manufacturor = model.Manufacturor;
                entity.ReleaseYear = model.ReleaseYear;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePlatform(int platformId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Platforms
                        .Single(e => e.PlatformId == platformId);

                ctx.Platforms.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
