namespace Methods
{
    using System;

    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public PersonalInfo OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            bool isOlder = false;
            DateTime firstStudentDate = this.OtherInfo.BirthDate;
            DateTime secondStudentDate = other.OtherInfo.BirthDate;

            if (DateTime.Compare(firstStudentDate, secondStudentDate) < 0)
            {
                isOlder = true;
            }

            return isOlder;
        }
    }
}
