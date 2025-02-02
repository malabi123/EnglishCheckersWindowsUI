namespace EnglishCheckers
{
    internal class Square
    {
        private Position m_Position;
        public eSoldierType SoldierType { get; set; }

        public Square(Position i_Position, eSoldierType i_Type)
        {
            m_Position = i_Position;
            SoldierType = i_Type;
        }

        internal Position Position
        {
            get
            {
                return m_Position;
            }
        }

        internal bool IsBlackSquare()
        {
            return Position.IsPositionDescribeBlackSquare();
        }

        internal bool IsSquareEmpty()
        {
            return SoldierType == eSoldierType.None;
        }

        internal void SoldierReset()
        {
            SoldierType = eSoldierType.None;
        }

        internal int GetSoldierPoints()
        {
            int points = 0;

            switch (SoldierType)
            {
                case eSoldierType.OKing:
                case eSoldierType.XKing:
                    points = 4;
                    break;
                case eSoldierType.ORegular:
                case eSoldierType.XRegular:
                    points = 1;
                    break;
            }

            return points;
        }

        internal char GetSquareSoldierSign()
        {
            return (char)SoldierType;
        }

        internal bool IsHoldingKing()
        {
            return SoldierType == eSoldierType.OKing || SoldierType == eSoldierType.XKing;
        }

        internal void PromoteSoldier()
        {
            if (SoldierType == eSoldierType.XRegular)
            {
                SoldierType = eSoldierType.XKing;
            }
            else if (SoldierType == eSoldierType.ORegular)
            {
                SoldierType = eSoldierType.OKing;
            }
        }

        internal bool isOpponentSoldierAtSquare(Player i_CurrentTurnPlayer)
        {
            bool result;

            if (i_CurrentTurnPlayer.GetSoldiersSign == 'X')
            {
                result = SoldierType == eSoldierType.OKing || SoldierType == eSoldierType.ORegular;
            }
            else
            {
                result = SoldierType == eSoldierType.XKing || SoldierType == eSoldierType.XRegular;
            }

            return result;
        }
    }
}        