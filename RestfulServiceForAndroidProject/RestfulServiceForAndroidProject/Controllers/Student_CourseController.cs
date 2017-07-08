using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestfulServiceForAndroidProject.Models;

namespace RestfulServiceForAndroidProject.Controllers
{
    public class Student_CourseController : ApiController
    {
        private MC_ProjectAssignerEntities db = new MC_ProjectAssignerEntities();

        // GET api/Student_Course
        public IEnumerable<Student_Course> GetStudent_Course()
        {
            return db.Student_Course.ToList();
        }

        // GET api/Student_Course/5
        [ResponseType(typeof(Student_Course))]
        public IHttpActionResult GetStudent_Course([FromUri]int id)
        {
            Student_Course student_course = db.Student_Course.Find(id);
            if (student_course == null)
            {
                return NotFound();
            }

            return Ok(student_course);
        }

        // PUT api/Student_Course/5
        public IHttpActionResult PutStudent_Course(int id, Student_Course student_course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student_course.SC_ID)
            {
                return BadRequest();
            }

            db.Entry(student_course).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Student_CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Student_Course
        [ResponseType(typeof(Student_Course))]
        public IHttpActionResult PostStudent_Course([FromBody]Student_Course student_course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Student_Course.Add(student_course);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student_course.SC_ID }, student_course);
        }

        // DELETE api/Student_Course/5
        [ResponseType(typeof(Student_Course))]
        public IHttpActionResult DeleteStudent_Course(int id)
        {
            Student_Course student_course = db.Student_Course.Find(id);
            if (student_course == null)
            {
                return NotFound();
            }

            db.Student_Course.Remove(student_course);
            db.SaveChanges();

            return Ok(student_course);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Student_CourseExists(int id)
        {
            return db.Student_Course.Count(e => e.SC_ID == id) > 0;
        }
    }
}