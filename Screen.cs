using Chess;
using tabletop;

namespace ConsoleChess
{
     class Screen
    {
        public static void PrintTabletop(Tabletop tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.columns; j++)
                {
                    if (tab.showPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(tab.showPiece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}