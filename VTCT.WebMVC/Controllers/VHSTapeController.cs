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
    public class VHSTapeController : Controller
    {
        // GET: VHSTape
        // Interacts with Views and Models
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VHSTapeService(userId);
            var model = service.GetVHSTapes();

            return View(model);
        }

		//GET
		// Interacts with Views and Models
		public ActionResult Create()
		{
			return View();
		}

        // VHS Create
		//Pushes data inputted in the view through our Service into the database
		[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VHSTapeCreate model) 
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

			var userId = Guid.Parse(User.Identity.GetUserId());
			var service = new VHSTapeService(userId);

			if (service.CreateVHSTape(model))
			{
                TempData["SaveResult"] = "Your VHS Tape was successfully created.";
				return RedirectToAction("Index");
			};

			ModelState.AddModelError("", "There was an error: VHS Tape could not be created.");

            return View(model);

        }

        // VHSTapeDetail
        public ActionResult Details(int id) 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VHSTapeService(userId);
            var model = service.GetVHSTapeById(id);

            return View(model);
        }

        // EDIT VHSTape
        public ActionResult Edit(int id) 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VHSTapeService(userId);
            var detail = service.GetVHSTapeById(id);
            var model =
                new VHSTapeEdit
                {
                    VHSTapeID = detail.VHSTapeID,
                    VHSTitle = detail.VHSTitle,
                    VHSDescription = detail.VHSDescription,
                    VHSGenre = detail.VHSGenre,
                    CollectionName = detail.CollectionName
                };

            return View(model);
        }

        // EDIT VHSTape Overload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, VHSTapeEdit model) 
        {
            if (!ModelState.IsValid) return View(model);

			if (model.VHSTapeID != id)
			{
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
			}

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VHSTapeService(userId);

            if (service.UpdateVHSTape(model)) 
            {
                TempData["SaveResult"] = "Your VHS Tape was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your VHS Tape could not be updated.");
            return View();
        }

        // DELETE VHSTape
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VHSTapeService(userId);
            var model = service.GetVHSTapeById(id);

            return View(model);
        }

        // DELETE VHSTape from Database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVHSTape(int id) 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VHSTapeService(userId);
            service.DeleteVHSTape(id);

            TempData["SaveResult"] = "Your VHS Tape was deleted";

            return RedirectToAction("Index");
        }

    }
}