using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VTCT.Models;
using VTCT.Services;

namespace VTCT.WebMVC.Controllers
{
    [Authorize]
    public class CollectionController : Controller
    {
        // GET: Collection
        // Interacts with Views and Models
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);
            var model = service.GetCollections();

            return View(model);
        }

        //GET
        // Interacts with Views and Models
        public ActionResult Create()
        {
            return View();
        }

        // TESTING -------------------------------------------------
        //public ActionResult Tapes()
        //{
        //    var userId = Guid.Parse(User.Identity.GetUserId());
        //    var service = new CollectionService(userId);
        //    var model = service.GetCollectionWithTapes1();

        //    return View(model);
        //}

        // TESTING -------------------------------------------------

        // VHS Create
        //Pushes data inputted in the view through our Service into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CollectionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);

            if (service.CreateCollection(model))
            {
                TempData["SaveResult"] = "Your Collection was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "There was an error: Collection could not be created.");

            return View(model);

        }

        // CollectionDetail
        public ActionResult Details(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);
            var model = service.GetCollectionById(id);

            return View(model);
        }

        // EDIT COLLECTION
        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);
            var detail = service.GetCollectionById(id);
            var model =
                new CollectionEdit
                {
                    CollectionID = detail.CollectionID,
                    CollectionName = detail.CollectionName,
                    CollectionDescription = detail.CollectionName
                };

            return View(model);
        }

        // EDIT Collection Overload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CollectionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CollectionID != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);

            if (service.UpdateCollection(model))
            {
                TempData["SaveResult"] = "Your Collection was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Collection could not be updated.");
            return View();
        }

        // DELETE Collection
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);
            var model = service.GetCollectionById(id);

            return View(model);
        }

        // DELETE Collection from Database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCollection(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CollectionService(userId);
            service.DeleteCollection(id);

            TempData["SaveResult"] = "Your VHS Tape was deleted";

            return RedirectToAction("Index");
        }

    }
}