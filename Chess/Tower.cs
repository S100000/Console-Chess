using tabletop;

namespace Chess
{
    public class Tower : Piece
    {
        public Tower(Color color, Tabletop tab) : base(color, tab)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}