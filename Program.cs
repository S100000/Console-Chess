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
                Tabletop tab = new Tabletop(8, 8);

                tab.PlacePiece(new Tower(Color.Black, tab), new Position(0, 0));
                tab.PlacePiece(new King(Color.Black, tab), new Position(1, 3));
                tab.PlacePiece(new Bishop(Color.Black, tab), new Position(4, 0));
                tab.PlacePiece(new Knight(Color.Black, tab), new Position(7, 3));
                tab.PlacePiece(new Knight(Color.Black, tab), new Position(6, 1));
                tab.PlacePiece(new Pawn(Color.Black, tab), new Position(1, 4));
                tab.PlacePiece(new Queen(Color.Black, tab), new Position(0, 1));
                tab.PlacePiece(new Pawn(Color.Black, tab), new Position(1, 9));
                

                Screen.PrintTabletop(tab);
            }
            catch (TabletopException e)
            {
                Console.WriteLine(e.Message);
            }
            
             Console.ReadLine();
        }
    }
}
