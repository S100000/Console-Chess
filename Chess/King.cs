

using System.Threading.Channels;
using tabletop;

namespace Chess
{
    public class King : Piece
    {

        private ChessMatch match;
        public King(Color color, Tabletop tab, ChessMatch match) : base(color, tab)
        {
            this.match = match;
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
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line - 1, pos.column + 1);//northeast king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line, pos.column + 1);//right king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column + 1);//southeast king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column);//below king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line + 1, pos.column - 1);//southwest king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line, pos.column - 1);//left king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            position.defineValues(pos.line - 1, pos.column - 1);//northwest king
            if (tab.isPositionValid(position) && CanMove(position))
            {
                mat[position.line, position.column] = true;
            }

            //#specialmoves castling
            if (qtdMoves == 0 && !match.check)
            {
                Position posT1 = new Position(pos.line, pos.column + 3);
                if (TestCastling(posT1))
                {
                    Position p1 = new Position(pos.line, pos.column + 1);
                    Position p2 = new Position(pos.line, pos.column + 2);
                    if (tab.showPiece(p1) == null && tab.showPiece(p2) == null)
                    {
                        mat[pos.line, pos.column + 2] = true;
                    }
                }
                
                Position posT2 = new Position(pos.line, pos.column - 4);
                if (TestCastling(posT2))
                {
                    Position p1 = new Position(pos.line, pos.column - 1);
                    Position p2 = new Position(pos.line, pos.column - 2);
                    Position p3 = new Position(pos.line, pos.column - 3);
                    if (tab.showPiece(p1) == null && tab.showPiece(p2) == null && tab.showPiece(p3) == null)
                    {
                        mat[pos.line, pos.column - 2] = true;
                    }
                }

            }
            return mat;
        }

        private bool TestCastling(Position position)
        {
            Piece p = tab.showPiece(position);
            return p != null && p is Tower && p.color == color && p.qtdMoves == 0;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}