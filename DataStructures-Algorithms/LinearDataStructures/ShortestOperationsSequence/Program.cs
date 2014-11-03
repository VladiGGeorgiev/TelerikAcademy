using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestOperationsSequence
{
    class Program
    {
        const int N = 5;
        const int M = 40;
        static List<int[]> allPaths = new List<int[]>();
        static Stack<int> currentPath = new Stack<int>();

        static void Main(string[] args)
        {            
            Tree root = new Tree(N);
            var treeOfSteps = CreateTree(root, N, M);

            DFS(treeOfSteps.Root);

            var minPaths = GetMinLengthPaths();

            PrintPaths(minPaths);
        }
  
        private static void PrintPaths(IEnumerable<int[]> minPaths)
        {
            foreach (var path in minPaths)
            {
                var currentPath = path.Reverse();
                foreach (var num in currentPath)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
            }
        }
  
        private static IEnumerable<int[]> GetMinLengthPaths()
        {
            var orderedPaths = allPaths.OrderBy(x => x.Count());
            int minPathLength = orderedPaths.First().Count();
            var minPaths = orderedPaths.Where(x => x.Count() == minPathLength);
            return minPaths;
        }

        private static void DFS(TreeNode node)
        {
            currentPath.Push(node.Value);
            if (node.Value == M)
            {
                if (allPaths.Count == 0 || currentPath.Count < allPaths[0].Count())
                {
                    allPaths.Add(currentPath.ToArray());
                }
            }
            foreach (var child in node.Children)
            {
                DFS(child);
            }
            currentPath.Pop();
        }
  
        private static Tree CreateTree(Tree tree, int currentNumber, int maxNumber)
        {
            int currentElement = currentNumber;

            if (currentElement > maxNumber)
            {
                return tree;
            }

            Tree currentChild = new Tree(currentElement * 2);
            if (currentElement * 2 <= maxNumber)
            {
                var currentTree = CreateTree(currentChild, currentElement * 2, maxNumber);
                tree.Root.AddChildren(currentTree);
            }

            currentChild = new Tree(currentElement + 2);
            if (currentElement + 2 <= maxNumber )
            {
                var currentTree = CreateTree(currentChild, currentElement + 2, maxNumber);
                tree.Root.AddChildren(currentTree);
            }

            currentChild = new Tree(currentElement + 1);
            if (currentElement + 1 <= maxNumber)
            {
                var currentTree = CreateTree(currentChild, currentElement + 1, maxNumber);
                tree.Root.AddChildren(currentTree);   
            }

            return tree;
        }
    }
}
