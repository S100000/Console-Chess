using Chess;
using tabletop;

namespace ConsoleChess
{
     class Screen
    {

        public static void PrintMatch(ChessMatch match)
        {
            PrintTabletop(match.tab);
            System.Console.WriteLine();
            PrintCapturedPieces(match);     
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.turn);
            System.Console.WriteLine("Waiting play: " + match.currentPlayer);
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            System.Console.WriteLine("Captured Pieces: ");
            System.Console.Write("White: ");
            PrintGroup(match.CapturedPieces(Color.White));
            System.Console.Write("Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintGroup(match.CapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            System.Console.WriteLine();
        }

        public static void PrintGroup(HashSet<Piece> group)
        {
            System.Console.Write("[");
            foreach (Piece x in group)
            {
                System.Console.Write(x + ", ");
            }
            System.Console.Write("] ");
        }
        public static void PrintTabletop(Tabletop tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.columns; j++)
                {
                    PrintPiece(tab.showPiece(i, j));
                }
                Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
        }

        public static void PrintTabletop(Tabletop tab, bool[,] PossiblePositions)
        {

            ConsoleColor originalBG = Console.BackgroundColor;
            ConsoleColor otherBG = ConsoleColor.Red;

            for (int i = 0; i < tab.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.columns; j++)
                {
                    if (PossiblePositions[i, j])
                    {
                        Console.BackgroundColor = otherBG;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBG;
                    }
                    PrintPiece(tab.showPiece(i, j));
                    Console.BackgroundColor = originalBG;
                }
                Console.WriteLine();
            }
            System.Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBG;
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

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}