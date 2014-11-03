using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using School;

namespace TestSchool
{
    [TestClass]
    public class SchoolTest
    {
        private List<Student> students = new List<Student>()
        {
            new Student("Pesho", 39399),
            new Student("Mincho", 39399),
            new Student("Dido", 39399),
        };


        [TestMethod]
        public void TestAddCourseWithValidCourse()
        {
            
            List<Course> courses = new List<Course>()
            {
                new Course("HTML", this.students),
                new Course("CSS", this.students),
                new Course("C#", this.students),
                new Course("JS", this.students),
            };

            School.School academy = new School.School("Telerik Academy", courses);
            var hqc = new Course("High Quality Code", students);
            academy.AddCourse(hqc);

            Assert.AreEqual(academy.Courses[4], hqc);
        }

        [TestMethod]
        public void TestRemoveCourseWithValidCourse()
        {  
            List<Course> courses = new List<Course>()
            {
                new Course("HTML", this.students),
                new Course("CSS", this.students),
                new Course("C#", this.students),
                new Course("JS", this.students),
            };

            School.School tu = new School.School("TU", courses);
            Course js = new Course("JS Part 2", students);
            
            tu.AddCourse(js);
            tu.RemoveCourse(js);

            Assert.IsFalse(tu.Courses.Contains(js));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestRemoveCourseWithNullValue()
        {
            List<Course> courses = new List<Course>()
            {
                new Course("HTML", this.students),
                new Course("CSS", this.students),
                new Course("C#", this.students),
                new Course("JS", this.students),
            };

            School.School tu = new School.School("TU", courses);
            tu.RemoveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRemoveCourseWithNonexistingCourse()
        {
            List<Course> courses = new List<Course>()
            {
                new Course("HTML", this.students),
                new Course("CSS", this.students),
                new Course("C#", this.students),
                new Course("JS", this.students),
            };

            School.School tu = new School.School("TU", courses);
            Course algo = new Course("Algorithms", students);
            tu.RemoveCourse(algo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddExistingCourse()
        {
            List<Course> courses = new List<Course>()
            {
                new Course("HTML", this.students),
                new Course("CSS", this.students),
                new Course("C#", this.students),
                new Course("JS", this.students),
            };

            School.School tu = new School.School("TU", courses);
            Course algo = new Course("Algorithms", students);
            tu.AddCourse(algo);
            tu.AddCourse(algo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddNullCourse()
        {
            List<Course> courses = new List<Course>()
            {
                new Course("HTML", this.students),
                new Course("CSS", this.students),
                new Course("C#", this.students),
                new Course("JS", this.students),
            };

            School.School tu = new School.School("TU", courses);
            tu.AddCourse(null);
        }
    }
}
