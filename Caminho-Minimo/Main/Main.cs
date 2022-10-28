using Caminho_Minimo.Graph;
using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Caminho_Minimo.Main
{
    internal class Main
    {
        public void mainOptions()
        {
            Console.WriteLine("Informe a tarefa :");
            Console.WriteLine("  1 - Caminho Minimo");
            Console.WriteLine("  2 - Labirinto");
            Console.WriteLine("  3 - Sair");
        }
        public int getValue(string argName)
        {
            int value;
            Console.WriteLine(argName + ":");
            value = Int16.Parse(Console.ReadLine() + "");
            return value;
        }

    
        public string readGraphName()
        {
            Console.Write("\nArquivo: ");
            string fileName = Console.ReadLine() + "";
            return fileName;
        }
    }
}
