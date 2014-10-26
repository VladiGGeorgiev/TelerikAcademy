using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Mustache.Services.Models
{
    [DataContract]
    public class Student
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "grade")]
        public byte Grade { get; set; }

        [DataMember(Name = "age")]
        public byte Age { get; set; }

        [DataMember(Name = "marks")]
        public List<Mark> Marks { get; set; }
    }
}