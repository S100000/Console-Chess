

using tabletop;

namespace Chess
{
    public class King : Piece
    {
        public King(Color color, Tabletop tab) : base(color, tab)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}