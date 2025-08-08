using tabletop;

namespace Chess
{
    public class Queen : Piece
    {
        public Queen(Color color, Tabletop tab) : base(color, tab)
        {
        }

         public override string ToString()
        {
            return "Q";
        }
    }
}