using tabletop;

namespace ConsoleChess
{
    class Screen
    {
        public static void PrintTabletop(Tabletop tab)
        {
            for (int i = 0; i < tab.lines; i++)
            {
                for (int j = 0; j < tab.columns; j++)
                {
                    if (tab.showPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.showPiece(i, j) + " ");
                    }
                        
                }
                Console.WriteLine();
            }
        }
    }
}