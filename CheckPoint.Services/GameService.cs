using CheckPoint.Data;
using CheckPoint.Models.GameModels;
using CheckPoint.Models.ReviewModel;
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
                    .Games.ToList()
                    .Select(
                        e =>
                        new GameListItem
                        {
                            GameId = e.GameId,
                            Title = e.Title,
                            Description = e.Description,
                            Platforms = e.Platforms,
                            Developer = e.Developer,
                            ESRB = e.ESRB,
                            ReleaseDate = e.ReleaseDate,
                            //AverageStarRating = e.AverageStarRating,
                            AllGameReviews = ConvertDataEntitiesToViewModel(e.AllGameReviews.ToList())
                        }
                        );
              var games = query.ToArray();
                return games;
            }
        }
        // This method will take in the List<Review> from my Game entity.
        public List<ReviewListItem> ConvertDataEntitiesToViewModel(List<Review> reviews)
        {
        // instantiate a new List<ReviewListItem>**
            List<ReviewListItem> returnList = new List<ReviewListItem>();
        // foreach through my entity.AllReviews 
            foreach (var review in reviews)
            {
                //create a new ReviewListItem
                var reviewListItem = new ReviewListItem();
                // assign it the values from the entity.AllReviews[i],
                reviewListItem.ReviewId = review.ReviewId;
                reviewListItem.Title = review.Title;
                reviewListItem.Content = review.Content;
                reviewListItem.StarRating = review.StarRating;
                reviewListItem.CreatedUtc = review.CreatedUtc;
               
                // add ReviewListItem to my List<ReviewListItem>**
                returnList.Add(reviewListItem);
            }
          //  return that List<ReviewListItem>**
            return returnList;
        }
        public GameDetail GetGameById(int id)
        {
            ReviewService reviewService = new ReviewService();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .SingleOrDefault(e => e.GameId == id);
                var detail = new GameDetail
                {
                    GameId = entity.GameId,
                    Title = entity.Title,
                    Description = entity.Description,
                    Platforms = entity.Platforms,
                    Developer = entity.Developer,
                    ESRB = (Models.GameModels.ESRB)entity.ESRB,
                    ReleaseDate = entity.ReleaseDate,
                    //AverageStarRating = entity.AverageStarRating,
                    AllGameReviews = ConvertDataEntitiesToViewModel(entity.AllGameReviews.ToList()) /*ConvertDataEntitiesToViewModel(entity.AllGameReviews)*/
                    //entity.AllGameReviews.Select(e => reviewService.GetReviewById(e.ReviewId)).ToList();
                };
                return detail;
                //foreach (Review review in entity.AllGameReviews)
                //{
                //    ReviewListItem reviewListItem = (ReviewListItem)reviewService.GetReview();
                //    detail.AllGameReviews.Add(reviewListItem);
                //}
                //return detail;
            }
        }



        public bool UpdateGame(GameEdit model)
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
