

using System.Security.Cryptography.X509Certificates;
using tabletop;

namespace Chess
{
    public class Bishop : Piece
    {
        public Bishop(Color color, Tabletop tab) : base(color, tab)
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

            //NW
            position.defineValues(pos.line - 1, pos.column - 1);
            while (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
                if (tab.showPiece(position) != null && tab.showPiece(position).color != color)
                {
                    break;
                }
                position.defineValues(position.line - 1, position.column - 1);
            }

            //NE
            position.defineValues(pos.line - 1, pos.column + 1);
            while (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
                if (tab.showPiece(position) != null && tab.showPiece(position).color != color)
                {
                    break;
                }
                position.defineValues(position.line - 1, position.column + 1);
            }

            //SE
            position.defineValues(pos.line + 1, pos.column + 1);
            while (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
                if (tab.showPiece(position) != null && tab.showPiece(position).color != color)
                {
                    break;
                }
                position.defineValues(position.line + 1, position.column + 1);
            }

            //SO
            position.defineValues(pos.line + 1, pos.column - 1);
            while (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
                if (tab.showPiece(position) != null && tab.showPiece(position).color != color)
                {
                    break;
                }
                position.defineValues(position.line + 1, position.column - 1);
            }

            return mat;
        }

        public override string ToString()
        {
            return "B";
        }
    }
}