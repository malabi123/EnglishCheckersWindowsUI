using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    internal class DirectionManager
    {
        private const Direction.eDirectionType k_Negative = Direction.eDirectionType.Negative;
        private const Direction.eDirectionType k_Positive = Direction.eDirectionType.Positive;
        public static readonly Direction[] sr_KingDirections = { new Direction(k_Negative, k_Negative), new Direction(k_Negative, k_Positive), new Direction(k_Positive, k_Negative), new Direction(k_Positive, k_Positive) };
        public static readonly Direction[] sr_UpperDirections = { new Direction(k_Positive, k_Negative), new Direction(k_Positive, k_Positive) };
        public static readonly Direction[] sr_LowerDirections = { new Direction(k_Negative, k_Negative), new Direction(k_Negative, k_Positive) };

        public static Direction[] GetSoldierDirections(eSoldierType soldierType, bool i_isPlayerUp)
        {
            Direction[] directions = null;

            switch (soldierType)
            {
                case eSoldierType.OKing:
                case eSoldierType.XKing:
                    directions = sr_KingDirections;
                    break;
                
                case eSoldierType.XRegular:
                case eSoldierType.ORegular:
                    if (i_isPlayerUp)
                    {
                        directions = sr_UpperDirections;
                    }
                    else
                    {
                        directions = sr_LowerDirections;
                    }
                    
                    break;
            }

            return directions;
        }        
    }
}
