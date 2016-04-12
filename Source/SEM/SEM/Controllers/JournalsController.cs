using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEM.Core.DAL;
using SEM.Core.Models;
using Microsoft.AspNet.Identity;
using SEM.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using SEM.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SEM.Controllers
{
    [Authorize]
    public class JournalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public static UserManager<ApplicationUser> UserManager
        {
            get
            {
                return new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            }
        }

        public static JournalViewModel Journal2Model(Journal j)
        {
            // Find user
            var user = UserManager.FindById(j.AspNetUserId.ToString());
            var model = new JournalViewModel
            {
                Id = j.Id,
                Title = j.Title,
                Author = user?.UserName,
            };

            return model;
        }

        public static void Model2Journal(JournalViewModel model, Journal journal)
        {
            journal.Id = model.Id;
            journal.Title = model.Title;

            var user = model.Author==null ? null : UserManager.FindByEmail(model.Author);
            if(user!=null)
                journal.AspNetUserId = new Guid(user.Id);

            if (model.PdfUpload != null) {
                journal.File = new byte[model.PdfUpload.ContentLength];
                model.PdfUpload.InputStream.Read(journal.File, 0, model.PdfUpload.ContentLength);
            }
        }

        // GET: Journals
        public ActionResult Index()
        {
            return View(db.Publications.ToList().ConvertAll(Journal2Model));
        }

        // GET: Journals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Publications.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(Journal2Model(journal));
        }

        // GET: Journals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Journals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JournalViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.PdfUpload == null)
                    return new HttpStatusCodeResult(HttpStatusCode.UnsupportedMediaType);

                Journal journal = new Journal();
                Model2Journal(model, journal);
                journal.AspNetUserId = new Guid(User.Identity.GetUserId());

                db.Publications.Add(journal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Journals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Publications.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(Journal2Model(journal));
        }

        // POST: Journals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JournalViewModel model)
        {
            if (ModelState.IsValid)
            {
                Journal journal = new Journal();
                Model2Journal(model, journal);
                journal.AspNetUserId = new Guid(User.Identity.GetUserId());

                db.Entry(journal).State = EntityState.Modified;
                Model2Journal(model, journal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Journals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Journal journal = db.Publications.Find(id);
            if (journal == null)
            {
                return HttpNotFound();
            }
            return View(journal);
        }

        // POST: Journals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Journal journal = db.Publications.Find(id);
            db.Publications.Remove(journal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
