using System;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Node
    {
        public IList<IList<int>> Connections;
        public int Value;

        public Node(int value)
        {
            Value = value;
            Connections = new List<IList<int>>();
        }
    }

    class Connection {
        public int A;
        public int B;

        public override int GetHashCode()
        {
            int hash = 37;
            unchecked
            {
                hash *= A * 97;
                hash += 19;
                hash *= B * 97;
                hash += 19;
                hash *= 43;
            }

            return hash;
        }

        public bool ConnectsTo(Node node) { 
            return node.Value == A || node.Value == B;
        }
    }

    internal class Program
    {
        

        static void Main(string[] args)
        {
            

            Console.ReadLine();
        }

        private static void ConnectTwoNodes(ISet<Connection> ignore, IList<Connection> pathTaken) { 

        }

        public static IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
        {

            IDictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < connections.Count; i++)
            {
                IList<int> connection = connections[i];
                if (connection[0] > connection[1])
                {
                    int temp = connection[0];
                    connection[0] = connection[1];
                    connection[1] = temp;
                }

                if (!nodes.TryGetValue(connection[0], out Node nodeA))
                {
                    nodeA = new Node(connection[0]);
                    nodes.Add(nodeA.Value, nodeA);
                }
                nodeA.Connections.Add(connection);

                if (!nodes.TryGetValue(connection[1], out Node nodeB))
                {
                    nodeB = new Node(connection[1]);
                    nodes.Add(nodeB.Value, nodeB);
                }
                nodeB.Connections.Add(connection);
            }

            IList<IList<int>> output = new List<IList<int>>();
            ISet<int> set = new HashSet<int>();

            foreach (var node in nodes.Values)
            {
                if (node.Connections.Count != 1) continue;

                int hash = 37;
                unchecked
                {
                    hash *= node.Connections[0][0] * 97;
                    hash += 19;
                    hash *= node.Connections[0][1] * 97;
                    hash += 19;
                }

                if (set.Contains(hash)) continue;
                set.Add(hash);

                output.Add(node.Connections[0]);
            }

            return output;
        }
    }
}