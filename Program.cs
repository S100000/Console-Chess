using System;
using Chess;
using tabletop;

namespace ConsoleChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();
                while (!match.finished)
                {
                    Console.Clear();
                    Screen.PrintTabletop(match.tab);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,] possiblePositions = match.tab.showPiece(origin).possibleMoves();
                    Console.Clear();
                    Screen.PrintTabletop(match.tab, possiblePositions);
                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.readPositionChess().toPosition();

                    match.PerformeMove(origin, destiny);
                } 
                
            }
            catch (TabletopException e)
            {
                Console.WriteLine(e.Message);
            }
            
             Console.ReadLine();
        }
    }
}
