using CheckPoint.Models.PlatformModel;
using CheckPoint.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CheckPoint.MVC.Controllers
{
    public class PlatformController : Controller
    {
        // GET: Platform
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlatformService(userId);
            var model = service.GetPlatform();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlatformCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlatformService();

            if (service.CreatePlatform(model))
            {
                TempData["SaveResult"] = "Your Platform was created.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Ash, you cannot use this item at this time.");

            return View(model);
        }

        private PlatformService CreatePlatformService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PlatformService(userId);
            return service;
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePlatformService();
            var model = svc.GetPlatformById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlatformService();
            var detail = service.GetPlatformById(id);
            var model =
                new PlatformEdit
                {
                    PlatformId = detail.PlatformId,
                    Title = detail.Title,
                    Description = detail.Description,
                    Manufacturor = detail.Manufacturor,
                    ReleaseYear = detail.ReleaseYear

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlatformEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlatformId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePlatformService();

            if (service.UpdatePlatform(model))
            {
                TempData["SaveResult"] = "Your Platform was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your game could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePlatformService();
            var model = svc.GetPlatformById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePlatformService();

            service.DeletePlatform(id);

            TempData["SaveResult"] = "Your platform was deleted";

            return RedirectToAction("Index");
        }
    }
}