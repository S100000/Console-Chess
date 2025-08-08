using System;
using tabletop;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabletop tab = new Tabletop(8, 8);

            Screen.PrintTabletop(tab);

            Console.ReadLine();
        }
    }
}
