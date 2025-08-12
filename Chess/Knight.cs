
using tabletop;

namespace Chess
{
    public class Knight : Piece
    {
        public Knight(Color color, Tabletop tab) : base(color, tab)
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

            position.defineValues(pos.line - 1, pos.column - 2);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line - 2, pos.column - 1);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line - 2, pos.column + 1);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line - 1, pos.column + 2);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column + 2);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 2, pos.column + 1);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 2, pos.column - 1);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column - 2);
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            return mat;
        }

        public override string ToString()
        {
            return "N";
        }
    }
}