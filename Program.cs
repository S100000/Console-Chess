using System;
using Chess;
using tabletop;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionChess poschess = new PositionChess('c', 7);
            Console.WriteLine(poschess);

            Console.WriteLine(poschess.toPosition());
             Console.ReadLine();
        }
    }
}
