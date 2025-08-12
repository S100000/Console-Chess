
using tabletop;

namespace Chess
{
    public class Pawn : Piece
    {
        public Pawn(Color color, Tabletop tab) : base(color, tab)
        {
        }

        private bool ThereIsAEnemy(Position position)
        {
            Piece p = tab.showPiece(position);
            return p != null && p.color != color;
        }

        private bool Free(Position position)
        {
            return tab.showPiece(position) ==  null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[tab.lines, tab.columns];
            Position position = new Position(0, 0);

            if (color == Color.White)
            {
                position.defineValues(pos.line - 1, pos.column);
                if (tab.isPositionValid(position) && Free(position))
                {
                    mat[position.line, position.column] = true;
                }

                position.defineValues(pos.line - 2, pos.column);
                Position p2 = new Position(pos.line - 1, pos.column);
                if (tab.isPositionValid(p2) && Free(p2) && tab.isPositionValid(position) && Free(position) && qtdMoves == 0)
                {
                    mat[position.line, position.column] = true;
                }

                position.defineValues(pos.line - 1, pos.column - 1);
                if (tab.isPositionValid(position) && ThereIsAEnemy(position))
                {
                    mat[position.line, position.column] = true;
                }

                position.defineValues(pos.line - 1, pos.column + 1);
                if (tab.isPositionValid(position) && ThereIsAEnemy(position))
                {
                    mat[position.line, position.column] = true;
                }
            }
            else
            {
                position.defineValues(pos.line + 1, pos.column);
                if (tab.isPositionValid(position) && Free(position))
                {
                    mat[position.line, position.column] = true;
                }

                position.defineValues(pos.line + 2, pos.column);
                Position p2 = new Position(pos.line + 1, pos.column);
                if (tab.isPositionValid(p2) && Free(p2) && tab.isPositionValid(position) && Free(position) && qtdMoves == 0)
                {
                    mat[position.line, position.column] = true;
                }

                position.defineValues(pos.line + 1, pos.column - 1);
                if (tab.isPositionValid(position) && ThereIsAEnemy(position))
                {
                    mat[position.line, position.column] = true;
                }

                position.defineValues(pos.line + 1, pos.column + 1);
                if (tab.isPositionValid(position) && ThereIsAEnemy(position))
                {
                    mat[position.line, position.column] = true;
                }
            }

            return mat;
        }

        public override string ToString()
        {
            return "p";
        }
    }
}