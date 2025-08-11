
using tabletop;

namespace Chess
{
    public class ChessMatch
    {
        public Tabletop tab{ get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }

        public ChessMatch()
        {
            tab = new Tabletop(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            finished = false;
            PlaceAllPieces();
        }

        public void PerformeMove(Position origin, Position destiny)
        {
            Piece p = tab.RemovePiece(origin);
            p.IcrementQtdMove();
            Piece capturedPiece = tab.RemovePiece(destiny);
            tab.PlacePiece(p, destiny);
        }

        public void makesAPlay(Position Origin, Position Destiny)
        {
            PerformeMove(Origin, Destiny);
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

        private void PlaceAllPieces()
        {
            tab.PlacePiece(new Tower(Color.White, tab), new PositionChess('c', 1).toPosition());
            tab.PlacePiece(new Tower(Color.White, tab), new PositionChess('c', 2).toPosition());
            tab.PlacePiece(new Tower(Color.White, tab), new PositionChess('d', 2).toPosition());
            tab.PlacePiece(new Tower(Color.White, tab), new PositionChess('e', 2).toPosition());
            tab.PlacePiece(new Tower(Color.White, tab), new PositionChess('e', 1).toPosition());
            tab.PlacePiece(new King(Color.White, tab), new PositionChess('d', 1).toPosition());

            tab.PlacePiece(new Tower(Color.Black, tab), new PositionChess('c', 7).toPosition());
            tab.PlacePiece(new Tower(Color.Black, tab), new PositionChess('c', 8).toPosition());
            tab.PlacePiece(new Tower(Color.Black, tab), new PositionChess('d', 7).toPosition());
            tab.PlacePiece(new Tower(Color.Black, tab), new PositionChess('e', 7).toPosition());
            tab.PlacePiece(new Tower(Color.Black, tab), new PositionChess('e', 8).toPosition());
            tab.PlacePiece(new King(Color.Black, tab), new PositionChess('d', 8).toPosition());
        }
    }
}