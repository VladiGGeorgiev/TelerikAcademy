using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using School;

namespace TestSchool
{
    [TestClass]
    public class CourseTest
    {
        private List<Student> students = new List<Student>()
            {
                new Student("Peter", 23213),
                new Student("Minka", 53664),
                new Student("Svetla", 27652),
                new Student("Desi", 97865),
                new Student("Stavri", 23433),
                new Student("Gosho", 12231),
                new Student("Stela", 77777),
                new Student("Valeri", 65674),
                new Student("Angel", 74756),
                new Student("Ivan", 13232),
                new Student("Svetoslav", 97999),
                new Student("Tihomir", 76566),
                new Student("Iliana", 45555),
                new Student("Jivko", 64654),
                new Student("Jivka", 12311),
                new Student("Dimcho", 44444),
                new Student("Dimitrichka", 52353),
                new Student("Desislava", 66346),
                new Student("Angela", 85634),
                new Student("Gergana", 63454),
                new Student("Silvia", 12345),
                new Student("Zlatina", 42444),
                new Student("Ivailo", 54363),
                new Student("Ivo", 31789),
                new Student("Minko", 91823),
                new Student("Stoyan", 98654),
                new Student("Stanislav", 23452),
                new Student("Gichka", 99965),
                new Student("Slavka", 77233),
            };

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestAddStudentException()
        {
            Course html = new Course("HTML", students);
            Student pesho = new Student("Peter", 29345);
            Student gosho = new Student("Georgi", 99922);
            html.AddStudent(pesho);
            html.AddStudent(gosho);
        }

        [TestMethod]
        public void TestRemoveExistingStudent()
        {
            Course cSharp = new Course("C#", students);
            Student mincho = new Student("Mincho", 23111);
            cSharp.AddStudent(mincho);
            mincho.Name = "isdsds";
            cSharp.RemoveStudent(mincho);

            Assert.AreEqual(students, cSharp.Students);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingMemberException))]
        public void TestRemoveNotExistingStudent()
        {
            Course css = new Course("CSS", students);
            Student koko = new Student("Kaloyan", 88823);

            css.RemoveStudent(koko);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCreateCourseWithMoreStudents()
        {
            this.students.Add(new Student("Alko", 39232));
            this.students.Add(new Student("Mashko", 33232));
            Course hqc = new Course("High Quality Code", students);
        }

        [TestMethod]
        public void TestGetName()
        {
            Course html = new Course("HTML", students);

            Assert.AreEqual("HTML", html.Name);
        }
    }
}
