using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud_operation_MVC.Models;

namespace Crud_operation_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //Retrival Data
        public ActionResult Index()
        {
            StudentDBHandle dbhandler = new StudentDBHandle();
            ModelState.Clear();
            return View(dbhandler.GetStudent());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    StudentDBHandle sdb = new StudentDBHandle();
                    if(sdb.AddStudnet(smodel))
                    {
                        ViewBag.Message = "Student Details Added ...";
                        ModelState.Clear();
                    }
                }


                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentModel smodel)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentModel smodel)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                if(sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
