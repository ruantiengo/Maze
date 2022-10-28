// See https://aka.ms/new-console-template for more information
using Caminho_Minimo.Graph;
using Caminho_Minimo.Main;

ConsoleKeyInfo taskOption;
Boolean isRunning = true;
Main main = new Main();
while (isRunning)
{
    main.mainOptions();
    taskOption = Console.ReadKey();
    Console.WriteLine("\n");
    string fileName;
    switch (taskOption.KeyChar)
    {
        case '1':{
            fileName = "../../../Files/cm/" + main.readGraphName();
             Graph g = new Graph(fileName);
                if (g.isValidGraph)
                {
                    int s = main.getValue("Origem");
                    int t = main.getValue("Destino");
                    g.BellmanFord(s, t);
                }

                break;
        }
        case '2':{
            fileName = "../../../Files/" + main.readGraphName();
            new Maze(fileName);
           
            break;
        }
        case '3':
            isRunning = false;
            break;
    }


}