using System;
using System.Collections.Generic;
using System.Linq;

namespace School
{
    class Discipline : ICommentable
    {
        private readonly string name;
        private int numberOfLectures;
        private int numberOfExercise;
        private List<string> comments;

        public Discipline(string name, int lecturesNumber, int exerciseNumber)
        {
            this.name = name;
            this.numberOfLectures = lecturesNumber;
            this.numberOfExercise = exerciseNumber;
            this.comments = new List<string>();
        }

        public int NumberOfExercise
        {
            get
            {
                return this.numberOfExercise;
            }

            set
            {
                this.numberOfExercise = value;
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                this.numberOfLectures = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
