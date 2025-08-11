
using System.Data.Common;
using tabletop;

namespace Chess
{
    public class ChessMatch
    {
        public Tabletop tab{ get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessMatch()
        {
            tab = new Tabletop(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            check = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            PlaceAllPieces();
        }

        public Piece PerformeMove(Position origin, Position destiny)
        {
            Piece p = tab.RemovePiece(origin);
            p.IcrementQtdMove();
            Piece capturedPiece = tab.RemovePiece(destiny);
            tab.PlacePiece(p, destiny);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMove(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = tab.RemovePiece(destiny);
            p.DecrementQtdMove();
            if (capturedPiece != null)
            {
                tab.PlacePiece(capturedPiece, destiny);
                captured.Remove(capturedPiece);
            }
            tab.PlacePiece(p, origin);
        }

        public void makesAPlay(Position Origin, Position Destiny)
        {
            Piece capturedPiece = PerformeMove(Origin, Destiny);

            if (IsInCheck(currentPlayer))
            {
                undoMove(Origin, Destiny, capturedPiece);
                throw new TabletopException("you can't put yourself in check");
            }

            if (IsInCheck(Opponent(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            turn++;
            changePlayer();

        }

        public void OriginValidate(Position pos)
        {
            if (tab.showPiece(pos) == null)
            {
                throw new TabletopException("There is no piece in the origin");
            }
            if (currentPlayer != tab.showPiece(pos).color)
            {
                throw new TabletopException("Is not your turn");
            }
            if (!tab.showPiece(pos).ThereArePossibleMoves())
            {
                throw new TabletopException("This piece can't move");
            }
        }

        public void DestinyValidate(Position origin, Position Destiny)
        {
            if (!tab.showPiece(origin).CanMoveTo(Destiny))
            {
                throw new TabletopException("Invalid Destiny.");
            }
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.White)
            {
                currentPlayer = Color.Black;
            }
            else
            {
                currentPlayer = Color.White;
            }

        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;
        }

        private Color Opponent(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool IsInCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new TabletopException("thers no " + color + "king");
            }

            foreach (Piece x in PiecesInGame(Opponent(color)))
            {
                bool[,] mat = x.possibleMoves();
                if (mat[K.pos.line, K.pos.column])
                {
                    return true;
                }
            }
            return false;
        }

        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            tab.PlacePiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }
        private void PlaceAllPieces()
        {
            PlaceNewPiece('c', 1, new Tower(Color.White, tab));
            PlaceNewPiece('c', 2, new Tower(Color.White, tab));
            PlaceNewPiece('d', 2, new Tower(Color.White, tab));
            PlaceNewPiece('e', 2, new Tower(Color.White, tab));
            PlaceNewPiece('e', 1, new Tower(Color.White, tab));
            PlaceNewPiece('d', 1, new King(Color.White, tab));
            
            PlaceNewPiece('c', 7, new Tower(Color.Black, tab));
            PlaceNewPiece('c', 8, new Tower(Color.Black, tab));
            PlaceNewPiece('d', 7, new Tower(Color.Black, tab));
            PlaceNewPiece('e', 7, new Tower(Color.Black, tab));
            PlaceNewPiece('e', 8, new Tower(Color.Black, tab));
            PlaceNewPiece('d', 8, new King(Color.Black, tab));
        }
    }
}