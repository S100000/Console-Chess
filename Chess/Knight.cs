using tabletop;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(Color color, Tabletop tab) : base(color, tab)
        {
        }

         public override string ToString()
        {
            return "N";
        }
    }
}