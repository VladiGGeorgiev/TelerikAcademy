using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPerson
{
    class PhoneRecord
    {
        private string name;
        private string town;
        private string phone;

        public PhoneRecord(string name, string town, string phone)
        {
            this.Name = name;
            this.Town = town;
            this.Phone = phone;
        }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>The phone.</value>
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        /// <summary>
        /// Gets or sets the town.
        /// </summary>
        /// <value>The town.</value>
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                this.town = value;
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
                this.name = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0}, Town: {1}, Phone: {2}", 
                this.name, this.town, this.phone);
            return result;
        }
    }
}
