using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caminho_Minimo.Graph
{
    internal class Maze
    {
        private Graph graph;
        private Boolean isValidGraph = true;
        public Maze(string fileName)
        {
            try
                {
                String[] fileLines = File.ReadAllLines(fileName);
                int qtdLines = fileLines.Length;
                int qtdCols = fileLines[0].Length;
                graph = new Graph(qtdLines * qtdCols);
                char[,] maze = new char[qtdLines, qtdCols];
                int source;
                int sink;

                int s = 0;
                int d = 0;


                for (int i = 0; i < qtdLines; i++)
                {
                    for(int j = 0; j < qtdCols; j++)
                    {
                        maze[i, j] = fileLines[i][j];
                    }
                }
                
                for (int u = 0; u < qtdLines; u++)
                {
                    for (int v = 0; v < qtdCols; v++)
                    {

                        if (maze[u,v] == ' ' || maze[u,v] == 'S' || maze[u,v] == 'E')
                        {
                            source = u * qtdCols + v;
                            sink = source + 1;
                            if (maze[u,v] == 'S')
                            {
                                s = source;
                            }
                            if (maze[u,v] == 'E')
                            {
                                d = source;
                            }
                            if (v < qtdCols - 1
                                    && (maze[u,v + 1] == ' ' || maze[u,v + 1] == 'S'
                                            || maze[u,v + 1] == 'E'))
                            {
                                this.graph.AddEdgeUnoriented((source), (sink), 1);
                            }
                            if (u < qtdLines - 1
                                    && (maze[u + 1,v] == ' ' || maze[u + 1,v] == 'S'
                                            || maze[u + 1,v] == 'E'))
                            {
                                this.graph.AddEdgeUnoriented((source), ((u + 1) * qtdCols + v), 1);
                            }
                        }
                    }
                }
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                graph.BellmanFord(s,d);
                stopwatch.Stop();
                Console.WriteLine($"Tempo passado: {stopwatch.Elapsed}");
                stopwatch.Restart();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                isValidGraph = false;
            }
        }
    }
}
