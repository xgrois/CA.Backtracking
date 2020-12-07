using System;
using System.Collections.Generic;

namespace FindPathBetweenVerticesDirectedGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::: Find path between vertices in a directed graph :::");

            Node n0 = new Node() { Id = 0 };
            Node n1 = new Node() { Id = 1 };
            Node n2 = new Node() { Id = 2 };
            Node n3 = new Node() { Id = 3 };
            Node n4 = new Node() { Id = 4 };
            Node n5 = new Node() { Id = 5 };
            Node n6 = new Node() { Id = 6 };
            Node n7 = new Node() { Id = 7 };

            n0.Neighs.Add(n3);
            n1.Neighs.Add(n0); n1.Neighs.Add(n2); n1.Neighs.Add(n4);
            n2.Neighs.Add(n7);
            n3.Neighs.Add(n4); n3.Neighs.Add(n5);
            n4.Neighs.Add(n3); n4.Neighs.Add(n6);
            n5.Neighs.Add(n6);
            n6.Neighs.Add(n7);

            int N = 8; // num of nodes
            List<Node> path = Solution.FindPath(n0, n5, N);

            Console.WriteLine($"Path {n0.Id} to {n5.Id}: [" + String.Join(" --> ", path) + "]");
        }
    }

    class Node
    {
        public int Id { get; set; }
        public List<Node> Neighs { get; set; } = new List<Node>();

        public override string ToString()
        {
            return $"{Id}";
        }
    }

    class Solution
    {
        internal static List<Node> FindPath(Node s, Node d, int N)
        {
            List<Node> path = new List<Node>();
            path.Add(s);

            bool[] visited = new bool[N];
            visited[s.Id] = true;

            ProcessNode(s, d, path, visited);

            if (path.Count > 1) return path;

            path.Remove(s);
            return path;

        }

        private static bool ProcessNode(Node s, Node d, List<Node> path, bool[] visited)
        {
            
            if (s == d) return true;

            foreach (Node n in s.Neighs)
            {
                if (!visited[n.Id])
                {
                    path.Add(n);
                    visited[n.Id] = true;
                    if (ProcessNode(n, d, path, visited))
                        return true;
                    path.Remove(n);
                }

            }

            return false;
        }
    }

}
