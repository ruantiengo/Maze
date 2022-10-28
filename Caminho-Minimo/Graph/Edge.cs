using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caminho_Minimo.Graph
{
    internal class Edge
    {
        private int source;
        private int sink;
        private int weight;

        public Edge(int source, int sink, int weight = 1)
        {
            this.source = source;
            this.sink = sink;
            this.weight = weight;
        }

        public int GetSource()
        {
            return source;
        }

        public void SetSource(int source)
        {
            this.source = source;
        }

        public int GetSink()
        {
            return sink;
        }

        public void SetSink(int sink)
        {
            this.sink = sink;
        }

        public int GetWeight()
        {
            return weight;
        }

        public void SetWeight(int weight)
        {
            this.weight = weight;
        }

        
        public String ToString()
        {
            return "(" + source + ", " + sink + ", " + weight + ")";
        }

        
        public int CompareTo(Edge e)
        {
            if (this.weight > e.weight)
                return 1;
            return -1;
        }
    }
}
