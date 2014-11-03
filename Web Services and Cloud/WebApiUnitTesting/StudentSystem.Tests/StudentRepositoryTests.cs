using System;
using System.Data.Entity;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Repositories;

namespace StudentSystem.Tests
{
    [TestClass]
    public class StudentRepositoryTests
    {
        private DbContext context;
        private IRepository<Student> repository;
        private static TransactionScope transactionScope;

        public StudentRepositoryTests()
        {
            this.context = new StudentSystemContext();
            this.repository = new EfRepository<Student>(context);
        }

        [TestInitialize]
        public void OpenTransaction()
        {
            transactionScope = new TransactionScope();
        }

        [TestCleanup]
        public void CloseTransaction()
        {
            transactionScope.Dispose();
        }

        [TestMethod]
        public void TestAddStudent()
        {
            var student = new Student()
                {
                    FirstName = "Pesho",
                    LastName = "Audito",
                };

            this.repository.Add(student);
            Assert.IsTrue(student.StudentId > 0);
        }

        [TestMethod]
        public void TestGetStudent()
        {
            var name = "Mangal";
            byte age = 30;
            byte grade = 1;
            var student = new Student()
            {
                FirstName = name,
                Age = age,
                Grade = grade
            };

            this.repository.Add(student);
            var dbStudent = this.repository.Get(student.StudentId);
            Assert.IsTrue(dbStudent.Age == age);
            Assert.IsTrue(dbStudent.FirstName == name);
            Assert.IsTrue(dbStudent.Grade == grade);
        }

        [TestMethod]
        public void TestGetStudentComplex()
        {
            var name = "Bidona";
            byte age = 255;
            byte grade = 3;
            var student = new Student()
            {
                FirstName = name,
                Age = age,
                Grade = grade,
                School = new School()
                    {
                        Name = "PMG",
                    }
            };

            this.repository.Add(student);
            var dbStudent = this.repository.Get(student.StudentId);
            Assert.IsTrue(dbStudent.Age == age);
            Assert.IsTrue(dbStudent.School.Name == "PMG");
            Assert.IsTrue(dbStudent.FirstName == name);
        }

        [TestMethod]
        public void TestDeleteStudent()
        {
            var name = "Minka";
            byte age = 1;
            byte grade = 5;
            var student = new Student()
            {
                FirstName = name,
                Age = age,
                Grade = grade,
                School = new School()
                {
                    Name = "PMG",
                }
            };

            this.repository.Add(student);
            this.repository.Delete(student.StudentId);
            var dbStudent = this.repository.Get(student.StudentId);
            Assert.IsTrue(dbStudent == null);
        }

        [TestMethod]
        public void TestUpdateStudent()
        {
            var name = "Pichka";
            byte age = 42;
            byte grade = 3;
            var student = new Student()
            {
                FirstName = name,
                Age = age,
                Grade = grade,
                School = new School()
                {
                    Name = "EG",
                }
            };

            this.repository.Add(student);
            var updatedName = "Gugutka Zaspalova";
            int id = student.StudentId;
            this.repository.Update(id, new Student()
                {
                    StudentId = id,
                    FirstName = updatedName,
                });
            var dbStudent = this.repository.Get(student.StudentId);
            Assert.IsTrue(dbStudent.FirstName == updatedName);
        }

        
    }
}
