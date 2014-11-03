namespace School
{
    using System;

    public class Student
    {
        private int uniqueNumber;
        private string name;

        public Student(string name, int uniqueID)
        {
            this.Name = name;
            this.UniqueNumber = uniqueID;
        }

        /// <summary>
        /// Gets or sets the unique number.
        /// </summary>
        /// <value>The unique number.</value>
        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The unique number must be in 10000 - 99999 range!");
                }

                this.uniqueNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("The name can not be empty!");
                }

                this.name = value;
            }
        }

    }
}
