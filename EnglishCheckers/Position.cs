namespace EnglishCheckers
{
    internal struct Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int i_row, int i_column)
        {
            Row = i_row;
            Column = i_column;
        }

        internal bool IsPositionDescribeBlackSquare()
        {
            return (Row + Column) % 2 != 0;
        }
    }
}