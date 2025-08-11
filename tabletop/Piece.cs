namespace tabletop
{
    public abstract class Piece
    {
        public Position pos { get; set; }
        public Color color { get; protected set; }
        public int qtdMoves { get; protected set; }

        public Tabletop tab { get; protected set; }

        public Piece(Color color, Tabletop tab)
        {
            this.pos = null;
            this.color = color;
            this.tab = tab;
            this.qtdMoves = 0;
        }

        public abstract bool[,] possibleMoves();

        public void IcrementQtdMove()
        {
            qtdMoves++;
        }

        public bool ThereArePossibleMoves()
        {
            bool[,] mat = possibleMoves();
            for (int i = 0; i < tab.lines; i++)
            {
                for (int j = 0; j < tab.columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position pos)
        {
            return possibleMoves()[pos.line, pos.column];
        }
    }
}