using CheckPoint.Models.ReviewModel;
using CheckPoint.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckPoint.MVC.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userId);
            var model = service.GetReview();
            return View(model);
        }
        public ActionResult Create()
        {
            var gameService = CreateGameService();
            var gameID = gameService.GetGames();
            var game = new SelectList(gameID.OrderBy(g=> g.Title).ToList(), "GameID", "Title");
            ViewBag.Game = game;
            return View();
        }
        public ActionResult CreateWithDefault(int gameId)
        {
            var reviewCreate = new ReviewCreate();
            reviewCreate.GameId = gameId;
            var gameService = CreateGameService();
            var gameID = gameService.GetGames();
            var game = new SelectList(gameID.OrderBy(g => g.Title).ToList(), "GameID", "Title");
            ViewBag.Game = game;
            return View("Create", reviewCreate);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateReviewService();

            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Your Game was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ash, you cannot use this item at this time.");

            return View(model);
        }
        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameservice = new GameService(userId);
            return gameservice; 
        }
            private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameService = new GameService(userId);

            var gameID = gameService.GetGames();
            var game = new SelectList(gameID, "GameID", "Title");
            ViewBag.Game = game;
            var service = new ReviewService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var gameService = CreateGameService();
            var gameID = gameService.GetGames();
            var game = new SelectList(gameID.OrderBy(g => g.Title).ToList(), "GameID", "Title");
            ViewBag.Game = game;
            var service = CreateReviewService();
            var detail = service.GetReviewById(id);
            var model =
                new ReviewEdit
                {
                    ReviewId = detail.ReviewId,
                    GameId = detail.GameId,
                    Title = detail.Title,
                    Content = detail.Content,
                    StarRating = detail.StarRating,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReviewId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateReviewService();

            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "Your game was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateReviewService();
            var model = svc.GetReviewById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}