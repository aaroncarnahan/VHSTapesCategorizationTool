using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VTCT.Models;
using VTCT.Models.Comment;
using VTCT.Services;

namespace VTCT.WebMVC.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var model = service.GetComments();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // Comment Create
        //Pushes data inputted in the view through our Service into the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);

            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your Comment was successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "There was an error: Comment could not be created.");

            return View(model);
        }

        // CommentDetail
        public ActionResult Details(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var model = service.GetCommentById(id);

            return View(model);
        }

        // EDIT Comment
        public ActionResult Edit(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var detail = service.GetCommentById(id);
            var model =
                new CommentEdit
                {
                    CommentID = detail.CommentID,
                    CommentContent = detail.CommentContent
                };

            return View(model);
        }

        // EDIT Comment Overload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CommentID != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);

            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Your VHS Tape was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Comment could not be updated.");
            return View();
        }

        // DELETE Comment
        public ActionResult Delete(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            var model = service.GetCommentById(id);

            return View(model);
        }

        // DELETE Comment from Database
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            service.DeleteComment(id);

            TempData["SaveResult"] = "Your Comment was deleted";

            return RedirectToAction("Index");
        }

    }
}