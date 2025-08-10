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
    }
}