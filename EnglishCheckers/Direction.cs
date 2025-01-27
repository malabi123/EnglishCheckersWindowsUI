using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    internal struct Direction
    {
        private readonly eDirectionType r_XDirection;
        private readonly eDirectionType r_YDirection;

        public Direction(eDirectionType i_XDirection, eDirectionType i_YDirection)
        {
            r_XDirection = i_XDirection;
            r_YDirection = i_YDirection;
        }

        public int XDirection
        {
            get
            {
                return (int)r_XDirection;
            }
        }

        public int YDirection
        {
            get
            {
                return (int)r_YDirection;
            }
        }

        public enum eDirectionType
        {
            Negative=-1,
            Positive=1
        }
    }
}
