using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ass_2.Models;

namespace ass_2.Controllers
{
    public class ComputersController : Controller
    {
        // GET: Computers
      

        private ass2Entities001 db = new ass2Entities001();

        // GET: Com
        
        // GET: Com/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            computers com = db.computers.Find(id);
            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }

        // GET: Com/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Com/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,category,price")] computers com)
        {
            if (ModelState.IsValid)
            {
                db.computers.Add(com);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(com);
        }

        // GET: Com/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            computers com = db.computers.Find(id);
            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }

        // POST: Com/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,category,price")] computers com)
        {
            if (ModelState.IsValid)
            {
                db.Entry(com).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(com);
        }

        // GET: Com/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            computers com = db.computers.Find(id);
            if (com == null)
            {
                return HttpNotFound();
            }
            return View(com);
        }

        // POST: Com/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            computers com = db.computers.Find(id);
            db.computers.Remove(com);
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
        public ActionResult Index(string sortOrder, string categoryFilter, string searchString)
        {
           

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";
            ViewBag.CategoryFilter = categoryFilter;

            var computers = from c in db.computers
                            select c;
            switch (sortOrder)
            {
                case "name_desc":
                    computers = computers.OrderByDescending(c => c.name);
                    break;
                case "Price":
                    computers = computers.OrderBy(c => c.price);
                    break;
                case "price_desc":
                    computers = computers.OrderByDescending(c => c.price);
                    break;
                default:
                    computers = computers.OrderBy(c => c.name);
                    break;
            }

            if (!String.IsNullOrEmpty(categoryFilter) && categoryFilter != "all")
            {
                computers = computers.Where(c => c.category == categoryFilter);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                computers = computers.Where(c => c.name.Contains(searchString));
            }
            return View(computers.ToList());
        }
    }
}