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
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(match);
                        Console.Write("Origin: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        match.OriginValidate(origin);

                        bool[,] possiblePositions = match.tab.showPiece(origin).possibleMoves();
                        Console.Clear();
                        Screen.PrintTabletop(match.tab, possiblePositions);
                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readPositionChess().toPosition();
                        match.DestinyValidate(origin, destiny);

                        match.makesAPlay(origin, destiny);
                    }
                    catch (TabletopException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Screen.PrintMatch(match);
                
            }
            catch (TabletopException e)
            {
                Console.WriteLine(e.Message);
            }
            
             Console.ReadLine();
        }
    }
}
