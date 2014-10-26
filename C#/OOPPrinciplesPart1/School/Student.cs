using System;
using System.Collections.Generic;

namespace School
{
    class Student : Person,  ICommentable
    {
        private long classNumberId;
        private List<string> comments;

        public Student(string name, long classNumber)
            : base(name)
        {
            this.classNumberId = classNumber;
            this.comments = new List<string>();
        }

        public long ClassNumberId
        {
            get
            {
                return this.classNumberId;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return string.Format("Name: " + this.Name + " Class number: " + this.ClassNumberId);
        }
    }
}
