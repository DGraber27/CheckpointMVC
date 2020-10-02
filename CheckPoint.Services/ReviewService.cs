using CheckPoint.Data;
using CheckPoint.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Services
{
    public class ReviewService
    {
        private readonly Guid _userId;
        public ReviewService() { }
        public ReviewService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {
                    GameId = model.GameId,
                    Title = model.Title,
                    Content = model.Content,
                    StarRating = model.StarRating,
                    CreatedUtc = DateTime.UtcNow
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReviewListItem> GetReview()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Reviews
                    .Select(
                        e =>
                        new ReviewListItem
                        {
                            ReviewId = e.ReviewId,
                            GameId = e.GameId,
                            Title = e.Title,
                            Content = e.Content,
                            StarRating = e.StarRating,
                            CreatedUtc = e.CreatedUtc
                        }
                        );
                return query.ToArray();
            }
        }

        public ReviewDetail GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == id);
                return
                    new ReviewDetail
                    {
                        ReviewId = entity.ReviewId,
                        GameId = entity.GameId,
                        Title = entity.Title,
                        Content = entity.Content,
                        StarRating = entity.StarRating

                    };
            }
        }

        public bool UpdateReview(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Reviews
                    .Single(e => e.ReviewId == model.ReviewId);
                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.StarRating = model.StarRating;
                entity.GameId = model.GameId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
