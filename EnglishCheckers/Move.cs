namespace EnglishCheckers
{
    internal struct Move
    {
        public Square StartSquare { get; }
        public Square EndSquare { get; }

        public Move(Square i_StartSquare, Square i_EndSquare)
        {
            StartSquare = i_StartSquare;
            EndSquare = i_EndSquare;
        }

        internal Position GetMiddleSquarePositionFromEatingMove()
        {
            int middleSquareRow = (StartSquare.Position.Row + EndSquare.Position.Row) / 2;
            int middleSquareColoumn = (StartSquare.Position.Column + EndSquare.Position.Column) / 2;
            Position middleSquarePosition = new Position(middleSquareRow, middleSquareColoumn);

            return middleSquarePosition;
        }
    }
}