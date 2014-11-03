using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalPath
{
    class Tree 
    {
        static List<int> PathsLength = new List<int>();
        static List<List<Node>> searchedPaths = new List<List<Node>>();
       
        static void Main()
        {
            int nodesNumber = int.Parse(Console.ReadLine());
            Node[] nodes = new Node[nodesNumber];

            for (int n = 0; n < nodesNumber; n++)
			{
			    nodes[n] = new Node(n);
			}

            ConnectNodesInTree(nodes);

            //a) - Find the root node
            Node root = FindTreeRoot(nodes);
            Console.WriteLine(root.Value);

            //b) - Find all leaf nodes
            List<int> leafNodes = FindLeafNodes(nodes);
            Console.WriteLine(string.Join(" ", leafNodes));

            //c) - Find all middle nodes
            List<int> middleNodes = FindMiddleNodes(nodes);
            Console.WriteLine(string.Join(" ", middleNodes));

            //d) - Find the longest path in the tree
            int maxHeight = FindMaxPath(root);

            //e) - all paths in the tree with given sum S of their nodes
            List<List<Node>> listOfPath = new List<List<Node>>();
            List<Node> currentPath = new List<Node>();
            FindPathWithSum(root, listOfPath, currentPath, 0, 8);
        }

        private static void FindPathWithSum(Node root, List<List<Node>> listOfPaths, List<Node> pathSoFar, int currentSum, int targetSum)
        {
            if (currentSum == targetSum)
            {
                Node[] nodePath = new Node[pathSoFar.Count];
                pathSoFar.CopyTo(nodePath);
                listOfPaths.Add(new List<Node>(nodePath));
                pathSoFar.RemoveRange(1, pathSoFar.Count - 1);
            }

            foreach (var item in root.Children)
            {
                pathSoFar.Add(item);
                FindPathWithSum(item, listOfPaths, pathSoFar, currentSum + item.Value, targetSum);
                if (pathSoFar.Count > 1)
                {
                    pathSoFar.RemoveAt(pathSoFar.Count - 1);
                }
            }
        }

        private static int FindMaxPath(Node node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int maxHeight = 0;
            foreach (var child in node.Children)
            {
                maxHeight = Math.Max(maxHeight, FindMaxPath(child));
            }

            maxHeight++;
            return maxHeight;
        }

        private static void ConnectNodesInTree(Node[] nodes)
        {
            for (int i = 0; i < nodes.Length - 1; i++)
            {
                string line = Console.ReadLine();

                string[] tokens = line.Split(' ');
                int currentParent = int.Parse(tokens[0]);
                int currentChild = int.Parse(tokens[1]);

                nodes[currentParent].AddChild(nodes[currentChild]);
                nodes[currentChild].HasParent = true;
            }
        }

        private static Node FindTreeRoot(Node[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].HasParent == false)
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("The tree has no root!");
        }

        private static List<int> FindLeafNodes(Node[] nodes)
        {
            List<int> leafNodes = new List<int>();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Children.Count == 0)
                {
                    leafNodes.Add(nodes[i].Value);
                }
            }

            return leafNodes;
        }
  
        private static List<int> FindMiddleNodes(Node[] nodes)
        {
            List<int> middleNodes = new List<int>();

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].HasParent && nodes[i].Children.Count > 0)
                {
                    middleNodes.Add(nodes[i].Value);
                }
            }

            return middleNodes;
        }
    }
}
