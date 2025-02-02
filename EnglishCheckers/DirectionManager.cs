namespace EnglishCheckers
{
    internal static class DirectionManager
    {
        private const Direction.eDirectionType k_Negative = Direction.eDirectionType.Negative;
        private const Direction.eDirectionType k_Positive = Direction.eDirectionType.Positive;
        public static readonly Direction[] sr_KingDirections = { new Direction(k_Negative, k_Negative),
                                                                 new Direction(k_Negative, k_Positive),
                                                                 new Direction(k_Positive, k_Negative),
                                                                 new Direction(k_Positive, k_Positive) };
        public static readonly Direction[] sr_UpperDirections = { new Direction(k_Positive, k_Negative),
                                                                  new Direction(k_Positive, k_Positive) };
        public static readonly Direction[] sr_LowerDirections = { new Direction(k_Negative, k_Negative),
                                                                  new Direction(k_Negative, k_Positive) };

        internal static Direction[] GetSoldierDirections(eSoldierType i_SoldierType, bool i_IsPlayerUp)
        {
            Direction[] directions = null;

            switch (i_SoldierType)
            {
                case eSoldierType.OKing:
                case eSoldierType.XKing:
                    directions = sr_KingDirections;
                    break;

                case eSoldierType.XRegular:
                case eSoldierType.ORegular:
                    if (i_IsPlayerUp)
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