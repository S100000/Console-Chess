using tabletop;

namespace Chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Tabletop tab) : base(color, tab)
        {
        }

         public override string ToString()
        {
            return "p";
        }
    }
}