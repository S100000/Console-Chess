namespace tabletop
{
    public class Piece
    {
        public Position pos { get; set; }
        public Color color { get; protected set; }
        public int qtdMoves { get; protected set; }

        public Tabletop tab { get; protected set; }

        public Piece(Position pos, Color color, Tabletop tab)
        {
            this.pos = pos;
            this.color = color;
            this.tab = tab;
            this.qtdMoves = 0;
        }
    }
}