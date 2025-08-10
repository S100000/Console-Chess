

using System.Threading.Channels;
using tabletop;

namespace Chess
{
    public class King : Piece
    {
        public King(Color color, Tabletop tab) : base(color, tab)
        {

        }

        private bool CanMove(Position pos)
        {
            Piece p = tab.showPiece(pos);
            return p == null || p.color != color;
        }
        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[tab.lines, tab.columns];
            Position position = new Position(0, 0);

            position.defineValues(pos.line - 1, pos.column);//above king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line - 1, pos.column + 1);//northeast king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line, pos.column + 1);//right king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column + 1);//southeast king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column);//below king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column - 1);//southwest king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line, pos.column - 1);//left king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            position.defineValues(pos.line - 1, pos.column - 1);//northwest king
            if (tab.isPositionValid(pos) && CanMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}