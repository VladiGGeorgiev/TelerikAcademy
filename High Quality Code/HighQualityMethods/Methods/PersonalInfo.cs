namespace Methods
{
    using System;

    public class PersonalInfo
    {
        public PersonalInfo(DateTime birthDate, string city, params string[] hobbies)
        {
            this.BirthDate = birthDate;
            this.City = city;
            this.Hobbies = hobbies;
        }

        public DateTime BirthDate { get; set; }

        public string City { get; set; }

        public string[] Hobbies { get; set; }
    }
}