using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using System.Data.Entity;

namespace CaseStudy.Controllers
{
    public class HomeController : Controller
    {
        Case_StudyEntities1 db = new Case_StudyEntities1();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.CollegeDetails.ToList();
            return View(data);
        }
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CollegeDetail c)
        { 
            db.CollegeDetails.Add(c);
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["InsertMessage"] = "<script>alert('Inserted')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["InsertMessage"] = "<script>alert('Not Inserted')</script>";
            }
            return View();  
        }

        public ActionResult Edit(int id)
        {
            var row = db.CollegeDetails.Where(model => model.Id == id).FirstOrDefault();    
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(CollegeDetail c)
        {
            db.Entry(c).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["UpdateMessage"] = "<script>alert('Modified')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateMessage"] = "<script>alert('Not Modified')</script>";
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            var datarow = db.CollegeDetails.Where(model => model.Id == id).FirstOrDefault();
            return View(datarow);
        }
        [HttpPost]

        public ActionResult Delete(CollegeDetail c)
        {
            db.Entry(c).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Inserted')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Not Inserted')</script>";
            }
            return View();
        }
    }
}