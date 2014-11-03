using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Repositories;
using StudentSystem.Models;

namespace StudentSystem.Data
{
    public static class DataMapper
    {
        public static Mark CreateOrLoadMark(IRepository<Mark> repository, Mark entity)
        {
            Mark mark = repository.Get(entity.MarkId);
            if (mark != null)
            {
                return mark;
            }

            Mark newAlbum = repository.Add(new Mark()
                {
                    Subject = entity.Subject,
                    Value = entity.Value
                });

            return newAlbum;
        }

        public static Student CreateOrLoadArtist(IRepository<Student> repository, Student entity)
        {
            Student student = repository.Get(entity.StudentId);
            if (student != null)
            {
                return student;
            }

            Student newStudent = repository.Add(new Student()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Age = entity.Age,
                Grade = entity.Grade,
                School = entity.School,
                Marks = entity.Marks,
            });

            return newStudent;
        }

        public static School CreateOrLoadSong(IRepository<School> repository, School entity)
        {
            School school = repository.Get(entity.SchoolId);
            if (school != null)
            {
                return school;
            }

            School newSchool = repository.Add(new School()
            {
                Name = entity.Name,
                Location = entity.Location,
                Students = entity.Students
            });

            return newSchool;
        } 

    }
}
