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
    }
}