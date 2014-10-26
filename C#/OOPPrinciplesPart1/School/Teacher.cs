using System;
using System.Collections.Generic;

namespace School
{
    class Teacher : Person, ICommentable
    {
        private List<string> comments;

        private List<Discipline> disciplines = new List<Discipline>();

        internal string Disciplines
        {
            get
            {
                string stringDisciplines = string.Empty;
                foreach (var item in this.disciplines)
                {
                    stringDisciplines += item + " ";
                }

                return stringDisciplines;
            }
        }

        public Teacher(string name)
            : base(name)
        {
            this.comments = new List<string>();
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
