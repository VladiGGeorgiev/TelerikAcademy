using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalPath
{
    public class Node
    {
        private int value;
        private List<Node> children;

        public Node(int value)
        {
            this.value = value;
            this.children = new List<Node>();
        }

        public bool HasParent { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public List<Node> Children
        {
            get
            {
                return this.children;
            }
        }

        public int ChildrenNumber
        {
            get
            {
                return children.Count;
            }
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }

        public Node GetChild(int index)
        {
            return this.children[index];
        }
    }
}
