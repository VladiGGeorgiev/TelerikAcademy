namespace StudentClass
{
    using System;
    using System.Text;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(
            string firstName,
            string middleName,
            string lastName,
            int ssn,
            string address,
            long mobilePhone,
            string email,
            byte course,
            Specialty spec,
            University uni,
            Faculty fac)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MiddleName = middleName;
            this.Ssn = ssn;
            this.PermanentAddress = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = spec;
            this.University = uni;
            this.Faculty = fac;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Ssn { get; set; }

        public string PermanentAddress { get; set; }

        public long MobilePhone { get; set; }

        public string Email { get; set; }

        public byte Course { get; set; }

        public Specialty Specialty { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        public static bool operator ==(Student student1, Student student2)
        {
            return (student1.FirstName == student2.FirstName) &&
                (student1.LastName == student2.LastName) &&
                (student1.Email == student2.Email) &&
                (student1.PermanentAddress == student2.PermanentAddress);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !((student1.FirstName == student2.FirstName) &&
                (student1.LastName == student2.LastName) &&
                (student1.Email == student2.Email) &&
                (student1.PermanentAddress == student2.PermanentAddress));
        }

        public override bool Equals(object obj)
        {
            if (this.Ssn == (obj as Student).Ssn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.LastName.GetHashCode() ^ this.Email.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("First name: {0}\n", this.FirstName));
            result.Append(string.Format("Middle name: {0}\n", this.MiddleName));
            result.Append(string.Format("Last name: {0}\n", this.LastName));
            result.Append("Mobile phone: " + this.MobilePhone);
            result.Append("\nAddress: " + this.PermanentAddress);
            result.Append("\nUniversity: " + this.University);
            result.Append("\nFaculty: " + this.Faculty);
            result.Append("\nCourse: " + this.Course);

            return result.ToString();
        }

        public object Clone()
        {
            Student pesho = new Student(this.FirstName, this.MiddleName, this.LastName, this.Ssn, this.PermanentAddress, this.MobilePhone, this.Email, this.Course, this.Specialty, this.University, this.Faculty);
            return pesho;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return string.Compare(this.FirstName, other.FirstName);
            }

            if (this.LastName.CompareTo(other.LastName) != 0)
            {
                return string.Compare(this.LastName, other.LastName);
            }

            if (this.Ssn.CompareTo(other.Ssn) != 0)
            {
                return this.Ssn - other.Ssn;
            }

            return 0;
        }
    }
}
