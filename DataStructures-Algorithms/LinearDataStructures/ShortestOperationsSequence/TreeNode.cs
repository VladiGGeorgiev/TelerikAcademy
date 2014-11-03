using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestOperationsSequence
{
    class TreeNode
    {
        private int value;
        private List<TreeNode> children;

        public List<TreeNode> Children
        {
            get
            {
                return this.children;
            }
        }

        public TreeNode(int value)
        {
            this.value = value;
            this.children = new List<TreeNode>();
        }

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

        public void AddChild(TreeNode child)
        {
            this.children.Add(child);
        }

        public void AddChildren(params Tree[] children)
        {
            foreach (var child in children)
            {
                this.children.Add(child.Root);
            }
        }

        public TreeNode GetChild(int index)
        {
            return this.children[index];
        }
    }
}
