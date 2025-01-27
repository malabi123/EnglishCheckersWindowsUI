using EnglishCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    internal class Square
    {
        private Position m_position;
        public eSoldierType SoldierType { get; set; }

        public Position Position
        {
            get { return m_position; }
        }

        public Square(Position i_position, eSoldierType i_type)
        {
            m_position = i_position;
            SoldierType = i_type;
        }

        public bool IsBlackSquare()
        {
            return Position.IsPositionDescribeBlackSquare();
        }

        public bool IsSquareEmpty()
        {
            return SoldierType == eSoldierType.None;
        }

        public void SoldierReset()
        {
            SoldierType = eSoldierType.None;
        }

        public int GetSoldierPoints()
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

        public char GetSquareSoldierSign()
        {         
            return (char)SoldierType;
        }

        public bool IsHoldingKing()
        {
            return SoldierType == eSoldierType.OKing || SoldierType == eSoldierType.XKing;
        }

        public void PromoteSoldier()
        {
            if(SoldierType==eSoldierType.XRegular)
            {
                SoldierType = eSoldierType.XKing;
            }
            else if (SoldierType == eSoldierType.ORegular)
            {
                SoldierType = eSoldierType.OKing;
            }
        }

        public bool isOpponentSoldierAtSquare(Player i_currentTurnPlayer)
        {
            bool result;

            if (i_currentTurnPlayer.GetSoldiersSign == 'X')
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

        