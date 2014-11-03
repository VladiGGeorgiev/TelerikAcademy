namespace WellNamedIdentifiers
{
    using System;

    /// <summary>
    ///     Person sex
    /// </summary>
    public enum Sex 
    { 
        /// <summary>
        ///     Male person
        /// </summary>
        Male,

        /// <summary>
        ///     Female person
        /// </summary>
        Female
    }

    /// <summary>
    ///     My main project class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        ///     Main method
        /// </summary>
        public static void Main()
        {
        }

        /// <summary>
        ///     Create new human.
        /// </summary>
        /// <param name="age">Human's age</param>
        public void CreateHuman(int age)
        {
            Human person = new Human();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Svetlin Nakov";
                person.Sex = Sex.Male;
            }
            else
            {
                person.Name = "Ina Dobrilova";
                person.Sex = Sex.Female;
            }
        }

        /// <summary>
        ///     Class that hold Human with name, age and sex.
        /// </summary>
        private class Human
        {
            /// <summary>
            ///     Gets and sets male or female is person.
            /// </summary>
            public Sex Sex { get; set; }

            /// <summary>
            ///     Gets and sets name of person.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            ///     Gets and sets how old are the person.
            /// </summary>
            public int Age { get; set; }
        }
    }
}
