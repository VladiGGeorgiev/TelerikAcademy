using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoGraphsFriendsOfPesho
{
    public class Node : IComparable
    {
        public Node(int id)
        {
            this.Id = id;
            this.IsHospital = false;
        }

        public int Id { get; set; }

        public List<Node> MyProperty { get; set; }

        public long DijkstraDistance { get; set; }

        public bool IsHospital { get; set; }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    public class Connection
    {
        public Connection(Node toNode, long distance)
        {
            this.ToNode = toNode;
            this.Distance = distance;
        }

        public Node ToNode { get; set; }

        public long Distance { get; set; }
    }

    class FriendsOfPesho
    {
        static void Main(string[] args)
        {
            #region Parse and make map
            string[] input = Console.ReadLine().Split(' ');
            int pointsNumbers = int.Parse(input[0]);
            int streetNumbers = int.Parse(input[1]);
            int hospitalNumber = int.Parse(input[2]);

            string[] hospitals = Console.ReadLine().Split(' ');

            Dictionary<Node, List<Connection>> map = new Dictionary<Node, List<Connection>>();
            Dictionary<int, Node> allNodes = new Dictionary<int, Node>();

            for (int i = 0; i < streetNumbers; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                int firstNode = int.Parse(tokens[0]);
                int secondNode = int.Parse(tokens[1]);
                int distance = int.Parse(tokens[2]);

                if (!allNodes.ContainsKey(firstNode))
                {
                    allNodes.Add(firstNode, new Node(firstNode));
                }

                if (!allNodes.ContainsKey(secondNode))
                {
                    allNodes.Add(secondNode, new Node(secondNode));
                }

                Node firstNodeObj = allNodes[firstNode];
                Node secondNodeObj = allNodes[secondNode];

                if (!map.ContainsKey(firstNodeObj))
                {
                    map.Add(firstNodeObj, new List<Connection>());
                }

                if (!map.ContainsKey(secondNodeObj))
                {
                    map.Add(secondNodeObj, new List<Connection>());
                }

                map[firstNodeObj].Add(new Connection(secondNodeObj, distance));
                map[secondNodeObj].Add(new Connection(firstNodeObj, distance));
            }

            for (int i = 0; i < hospitals.Length; i++)
            {
                int currentHospital = int.Parse(hospitals[i]);
                allNodes[currentHospital].IsHospital = true;
            }
#endregion

            long result = long.MaxValue;
            for (int i = 0; i < hospitals.Length; i++)
            {
                int current = int.Parse(hospitals[i]);
                Dijkstra(map, allNodes[current]);

                long tempSum = 0;
                foreach (var node in allNodes)
                {
                    if (!node.Value.IsHospital)
                    {
                        tempSum += node.Value.DijkstraDistance;
                    }
                }

                if (tempSum < result)
                {
                    result = tempSum;
                }
            }

            Console.WriteLine(result);
        }

        static void Dijkstra(Dictionary<Node, List<Connection>> map, Node source)
        {
            PriorityQueue<long, Node> queue = new PriorityQueue<long, Node>();

            foreach (var node in map)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }
            source.DijkstraDistance = 0;

            queue.Enqueue(source.DijkstraDistance, source);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue().Value;

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var connection in map[currentNode])
                {
                    var distance = currentNode.DijkstraDistance + connection.Distance;

                    if (distance < connection.ToNode.DijkstraDistance)
                    {
                        connection.ToNode.DijkstraDistance = distance;
                        queue.Enqueue(connection.ToNode.DijkstraDistance, connection.ToNode);
                    }
                }
            }
        }
    }
}
