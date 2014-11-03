using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPerson
{
    class Command
    {
        string name;
        string[] parameters;

        public Command(string name, params string[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        /// <summary>
        /// Gets or sets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public string[] Parameters
        {
            get
            {
                return this.parameters;
            }
            set
            {
                this.parameters = value;
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
    }
}
