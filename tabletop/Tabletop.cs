
using System.IO.Compression;
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

        public Piece showPiece(Position Pos)
        {
            return pieces[Pos.line, Pos.column];
        }

        public void PlacePiece(Piece p, Position pos)
        {
            if (TheresAPiece(pos))
            {
                throw new TabletopException("There is a pice in that position");
            }
            pieces[pos.line, pos.column] = p;
            p.pos = pos;
        }

        public Piece? RemovePiece(Position pos)
        {
            if (showPiece(pos) == null)
            {
                return null;
            }
            Piece aux = showPiece(pos);
            aux.pos = null;
            pieces[pos.line, pos.column] = null;
            return aux;
        }

        public bool TheresAPiece(Position pos)
        {
            validatePosition(pos);
            return showPiece(pos) != null;
        }
        public bool isPositionValid(Position pos)
        {
            if (pos.line < 0 || pos.line >= lines || pos.column < 0 || pos.column >= columns)
            {
                return false;
            }

            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!isPositionValid(pos))
            {
                throw new TabletopException("Invalid Position");
            }
        }
    }
}