using Caminho_Minimo.Graph;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Caminho_Minimo.Graph
{
    internal class Graph
    {
        private int countNodes;
        private int countEdges;
        private List<List<Edge>> adjList;
        private List<Edge> edgeList;
        private static int INFINITY = 999999;
        public Boolean isValidGraph = true;

        public Graph(int countNodes)
        {
            this.countNodes = countNodes;
            adjList = new(this.countNodes);
            for (int i = 0; i < countNodes; i++)
            {
                adjList.Add(new List<Edge>());
            }
            edgeList = new();
        }

        public Graph(string fileName)
        {
            try
            {
                string[] fileLines = File.ReadAllLines(fileName);
                String[] line = fileLines[0].Split(" ");
                countNodes = int.Parse(line[0]);
                int qtdLines = int.Parse(line[1]);
                adjList = new(this.countNodes);
                for (int i = 0; i < countNodes; i++)
                {
                    adjList.Add(new());
                }
                edgeList = new();

                for (int i = 1; i < qtdLines; i++)
                {
                    String[] edgeInfo = fileLines[i].Split(" ");
                    int source = int.Parse(edgeInfo[0]);
                    int sink = int.Parse(edgeInfo[1]);
                    int weight = int.Parse(edgeInfo[2]);
                    AddEdge(source, sink, weight);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Erro. Tente novamente com outro arquivo.");
                isValidGraph = false;
            }
        }

    


            public void AddEdge(int source, int sink, int weight)
            {
                if (source < 0 || source > this.countNodes - 1
                        || sink < 0 || sink > this.countNodes - 1 || weight <= 0)
                {
                    Console.WriteLine("Invalid edge: " + source + sink + weight);
                    return;
                }
                adjList.ElementAt(source).Add(new Edge(source, sink, weight));
                edgeList.Add(new Edge(source, sink, weight));
                this.countEdges++;
            }
        
            public void AddEdgeUnoriented(int source, int sink, int weight)
            {
                AddEdge(source, sink, weight);
                AddEdge(sink, source, weight);
            }

            void Path(int[] parent, int vertex, List<int> path)
            {
                if (vertex < 0)
                {
                    return;
                }

                Path(parent, parent[vertex], path);
                path.Add(vertex);
            }
        
        public void BellmanFord(int s, int t)
        {
            
            int n = countNodes;
            int[] dist = new int[n];
            int[] parent = new int[n];

            for (int i = 0; i < n; i++)
            {
                dist[i] = INFINITY;

                parent[i] = -1;
            }

            dist[s] = 0;
            
            for (int i = 0; i < n - 1; i++)
            {
                
                    foreach (Edge edge in edgeList)
                    {
                        int u = edge.GetSource();
                        int v = edge.GetSink();
                        int w = edge.GetWeight();

                        if (dist[u] != INFINITY && dist[u] + w < dist[v])
                        {
                         
                            dist[v] = dist[u] + w;

                            parent[v] = u;
                        }
                    }

            }
           
                foreach (Edge edge in edgeList)
                {
                    int u = edge.GetSource();
                    int v = edge.GetSink();
                    int w = edge.GetWeight();

                    if (dist[u] != INFINITY && dist[u] + w < dist[v])
                    {
                        Console.WriteLine("Negative-weight cycle is found!!");
                        return;
                    }

                }
            
          

            if (t != s && dist[t] < INFINITY)
            {
                List<int> path = new();
                Path(parent, t, path);
                Console.WriteLine("Caminho: ");
                path.ForEach(p => Console.Write(p + " - "));
                Console.WriteLine("\nCusto: " + dist[t]);
            }

        }

    }
}
