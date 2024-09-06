﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Cache;
using StudentAndCourseCrudNHibernateDemo.Data;
using StudentAndCourseCrudNHibernateDemo.Models;

namespace StudentAndCourseCrudNHibernateDemo.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var students = session.Query<Student>().ToList();
                return View(students);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {

            if (student.Course.Id == 0)
            {
                ModelState.Remove("Course.Id"); //remove validation on the id field
            }

            if (ModelState.IsValid)
            {

                using (var session = NHibernateHelper.CreateSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        student.Course.Student = student;
                        session.Save(student);
                        transaction.Commit();
                    }
                }
            }
            return RedirectToAction("Index");

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Query<Student>().SingleOrDefault(u => u.Id == id);
                return View(student);
            }
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    if (student.Course != null)
                    {
                        student.Course.Student = student;
                        session.Update(student);
                        transaction.Commit();

                    }
                    return RedirectToAction("Index");

                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                return View(student);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteStudent(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var student = session.Get<Student>(id);
                    session.Delete(student);
                    transaction.Commit();
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            using (var session = NHibernateHelper.CreateSession())
            {
                var student = session.Get<Student>(id);
                return View(student);
            }
        }
    }
}