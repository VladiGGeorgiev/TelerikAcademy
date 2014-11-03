using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestOperationsSequence
{
    class Tree
    {
        private TreeNode root;

        public TreeNode Root
        {
            get
            {
                return this.root;
            }
        }

        public Tree(int value)
        {
            this.root = new TreeNode(value);
        }

        public Tree(int value, params Tree[] children) : this(value)
        {
            foreach (var child in children)
            {
                this.root.AddChild(child.root);
            }
        }
    }
}
