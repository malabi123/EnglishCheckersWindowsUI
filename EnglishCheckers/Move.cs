using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    internal struct Move
    {
        public Square StartSquare {  get; }
        public Square EndSquare { get; }

        public Move(Square i_startSquare, Square i_endSquare)
        {
            StartSquare = i_startSquare;
            EndSquare = i_endSquare;
        }

        public Position GetMiddleSquarePositionFromEatingMove()
        {
            int middleSquareRow = (StartSquare.Position.Row + EndSquare.Position.Row)/2;
            int middleSquareColoumn = (StartSquare.Position.Column + EndSquare.Position.Column) / 2;
            Position middleSquarePosition = new Position(middleSquareRow, middleSquareColoumn);

            return middleSquarePosition;
        }
    }
}