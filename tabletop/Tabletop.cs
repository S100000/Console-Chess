
using System.Xml;

namespace tabletop
{
    public class Tabletop
    {
        public int lines { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces;

        public Tabletop(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece showPiece(int line, int column)
        {
            return pieces[line, column];
        }
    }
}