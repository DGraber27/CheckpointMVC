using CheckPoint.Data;
using CheckPoint.Models.GameModels;
using CheckPoint.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace CheckPoint.MVC.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            var model = service.GetGames();
            return View(model);
        }

        public ActionResult Create()
        {
            var platformservice = CreatePlatformService();

            var platformID = platformservice.GetPlatform();
            var platform = new SelectList(platformID, "PlatformID", "Title");
            ViewBag.Platform = platform;
            return View();
        }

        private PlatformService CreatePlatformService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var platformservice = new PlatformService(userId);
            return platformservice;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameService();


            if (service.CreateGame(model))
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
            var service = new GameService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {

            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var platformservice = CreatePlatformService();
            var platformID = platformservice.GetPlatform();
            var platform = new SelectList(platformID, "PlatformID", "Title");
            ViewBag.Platform = platform;
            var service = CreateGameService();
            var detail = service.GetGameById(id);
            var model =
                new GameEdit
                {
                    
                    Title = detail.Title,
                    Description = detail.Description,
                    PlatformID = detail.PlatformID,
                    Developer = detail.Developer,
                    ESRB = detail.ESRB,
                    ReleaseDate = detail.ReleaseDate

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GameId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGameService();
            HttpPostedFileBase file = Request.Files["ImageData"];
            if (service.UpdateGame(file, model))
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
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        private GameImageService CreateGameImageService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var gameImageservice = new GameImageService(userId);
            return gameImageservice;
        }

        public ActionResult GetGameImages(int id)
        {
            GameImageListItems gameImages = new GameImageListItems(id);
            return PartialView("Create_Image", gameImages);

        }
        [HttpPost]
        [ActionName("Create_Image")]
        public ActionResult AddGameImages(GameImageListItems imageCreate)
        {
            var gameImageCreate = new GameImageListItems();
            var service = CreateGameImageService();
            var images = imageCreate.MapToModel();
            for (int i = 0; i < images.Count(); i++)
            {
                //images.ElementAt(i).CreateDate = DateTime.Now;
                //images.ElementAt(i).CreateUserId = User.Identity.GetUserId<int>();
                //images.ElementAt(i).UpdateDate = DateTime.Now;
                service.CreateGameImage(imageCreate);
            }
            return RedirectToAction("GameImages", new { id = gameImageCreate.GameId });
        }
        [HttpPost]
        public FileResult GetGameImage(int id)
        {
            GameImageListItems img = CreateGameImageService().GetGameImageById(id);
            return File(img.FileContent, img.FileType, img.FileName);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGameImage(int id)
        {
            var service = CreateGameImageService();
  
            service.DeleteGameImage(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
    }
}