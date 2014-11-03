using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Graphs_MaxPath
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

    class Program
    {
        static long maxPath = long.MinValue;
        static HashSet<int> visited = new HashSet<int>();
        static Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        static void Main(string[] args)
        {
            #region Read input
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n - 1; i++)
            {
                string[] tokens = Console.ReadLine().Split(new char[] { '<', '-', ' ', ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(tokens[0]);
                int child = int.Parse(tokens[1]);
                
                if (nodes.ContainsKey(parent) && nodes.ContainsKey(child))
                {
                    nodes[parent].AddChild(nodes[child]);
                    nodes[child].AddChild(nodes[parent]);
                }
                else if (nodes.ContainsKey(parent))
                {
                    Node childNode = new Node(child);
                    nodes.Add(childNode.Value, childNode);
                    nodes[parent].AddChild(nodes[child]);
                    nodes[child].AddChild(nodes[parent]);
                }
                else if (nodes.ContainsKey(child))
                {
                    Node parentNode = new Node(parent);
                    nodes.Add(parentNode.Value, parentNode);
                    nodes[parent].AddChild(nodes[child]);
                    nodes[child].AddChild(nodes[parent]);
                }
                else
                {
                    Node childNode = new Node(child);
                    Node parentNode = new Node(parent);
                    nodes.Add(childNode.Value, childNode);
                    nodes.Add(parentNode.Value, parentNode);
                    nodes[parent].AddChild(nodes[child]);
                    nodes[child].AddChild(nodes[parent]);
                }

            }
            #endregion

            foreach (var node in nodes)
            {
                if (node.Value.ChildrenNumber == 1)
                {
                    FindMaxPath(node, 0);
                    visited.Clear();
                }
            }

            Console.WriteLine(maxPath);
        }

        private static void FindMaxPath(KeyValuePair<int, Node> node, long sum)
        {
            if (node.Value.ChildrenNumber == 1 && sum != 0)
            {
                sum += node.Value.Value; 
                if (sum > maxPath)
                {
                    maxPath = sum;
                }

                return;
            }

            sum += node.Value.Value;
            visited.Add(node.Value.Value);

            foreach (var neighbour in node.Value.Children)
            {
                if (!visited.Contains(neighbour.Value))
                {
                    FindMaxPath(new KeyValuePair<int, Node>(neighbour.Value, neighbour), sum);
                }
            }
        }
    }
}
