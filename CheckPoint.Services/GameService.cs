﻿using CheckPoint.Data;
using CheckPoint.Models.GameModels;
using CheckPoint.Models.ReviewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CheckPoint.Services
{
    public class GameService
    {
        private readonly Guid _userId;


        public GameService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGame(HttpPostedFileBase file, GameCreate model)
        {
            model.GameImage = ConvertToBytes(file);
            var entity =
                new Game()
                {
                    GameImage = model.GameImage,
                    Title = model.Title,
                    Description = model.Description,
                    PlatformId = model.PlatformID,
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


        public byte[] GetImageFromDB(int id)
        {
            using (var game = new ApplicationDbContext())
            {
                var q = from temp in game.Games where temp.GameId == id select temp.GameImage;
                byte[] cover = q.First();
                return cover;
            }
        }
        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
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
                            //AllGameImages = ConvertDataEntitiesToImageViewModel(e.AllGameImages.ToList()),
                            GameId = e.GameId,
                            Title = e.Title,
                            Description = e.Description,
                            PlatTitle = e.Platform.Title,
                            Developer = e.Developer,
                            ESRB = (Models.GameModels.ESRB)e.ESRB,
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
        //public List<GameImageListItems> ConvertDataEntitiesToImageViewModel(List<GameImage> images)
        //{
        //    // instantiate a new List<ReviewListItem>**
        //    List<GameImageListItems> returnList = new List<GameImageListItems>();
        //    // foreach through my entity.AllReviews 
        //    foreach (var image in images)
        //    {
        //        //create a new ReviewListItem
        //        var gameImageListItem = new GameImageListItems();
        //        // assign it the values from the entity.AllReviews[i],
        //        gameImageListItem.GameImageId = image.GameImageID;
        //        gameImageListItem.FileContent = image.FileContent;
        //        gameImageListItem.FileName = image.FileName;
        //        gameImageListItem.FileType = image.FileType;
        //        gameImageListItem.FileSize = image.FileSize;

        //        // add ReviewListItem to my List<ReviewListItem>**
        //        returnList.Add(gameImageListItem);
        //    }
        //    //  return that List<ReviewListItem>**
        //    return returnList;
        //}
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
                    //AllGameImages = ConvertDataEntitiesToImageViewModel(entity.AllGameImages.ToList()),
                    GameId = entity.GameId,
                    Title = entity.Title,
                    Description = entity.Description,
                    PlatformID = entity.PlatformId,
                    PlatTitle = entity.Platform.Title,
                    Developer = entity.Developer,
                    ESRB = (Models.GameModels.ESRB)entity.ESRB,
                    ReleaseDate = entity.ReleaseDate,
                    //AverageStarRating = entity.AverageStarRating,
                    AllGameReviews = ConvertDataEntitiesToViewModel(entity.AllGameReviews.ToList())
                };
                return detail;

            }
        }



        public bool UpdateGame(HttpPostedFileBase file, GameEdit model)
        {
            model.GameImage = ConvertToBytes(file);
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                   .Where(e => e.GameId == model.GameId).FirstOrDefault();
                //.Single(e => e.GameId == model.GameId);
                if (entity != null)
                {
                    entity.GameImage = model.GameImage;
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.PlatformId = model.PlatformID;
                    entity.Developer = model.Developer;
                    entity.ESRB = (Data.ESRB)model.ESRB;
                    entity.ReleaseDate = model.ReleaseDate;
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Where(e => e.GameId == gameId).FirstOrDefault();

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
