using tabletop;

namespace Chess
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Tabletop tab) : base(color, tab)
        {
        }

         public override string ToString()
        {
            return "B";
        }
    }
}