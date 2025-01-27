using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    internal class Board
    {
        private readonly Square[,] r_GameBoard;
        private readonly eBoardSize r_BoardSize;
        public readonly bool r_IsXUp=false;

        public Board(eBoardSize i_size)
        {
            r_BoardSize = i_size;
            r_GameBoard = new Square[(int)r_BoardSize, (int)r_BoardSize];
            r_IsXUp = false;

            initializeSquaresAndBoard();
        }
        
        public int GameBoardSize
        {
            get
            {
                return (int)r_BoardSize;
            }
        }

        public bool IsXUp
        {
            get { return r_IsXUp; }
        }

        public void UpdateMove(Move i_move,Player i_cuurentTurnPlayer)
        {
            i_move.EndSquare.SoldierType = i_move.StartSquare.SoldierType;
            i_move.StartSquare.SoldierReset();
            checkAndPromote(i_move.EndSquare, i_cuurentTurnPlayer);
        }

        public void UpdateEatingMove(Move i_move, Player i_cuurentTurnPlayer)
        {
            Position middleSquarePosition = i_move.GetMiddleSquarePositionFromEatingMove();
            Square middleSquare = GetSquareInPositionWithoutValidationCheck(middleSquarePosition);
            
            middleSquare.SoldierReset();
            UpdateMove(i_move,i_cuurentTurnPlayer);
        }

        public Square GetSquareInPosition(Position i_position)
        {
            Square square = null;

            if (IsPositionOnBoard(i_position))
            {
                square = r_GameBoard[i_position.Row, i_position.Column];
            }

            return square;
        }

        public Square GetSquareInPositionWithoutValidationCheck(Position i_position)
        {
            return r_GameBoard[i_position.Row, i_position.Column]; ;
        }

        public bool IsPositionOnBoard(Position i_position)
        {
            int row = i_position.Row;
            int col = i_position.Column;

            return row >= 0 && row < GameBoardSize && col >= 0 && col < GameBoardSize;
        }

        private void initializeSquaresAndBoard()
        {
            int size = GameBoardSize;
            int playerRows = (size / 2) - 1;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Position position = new Position(row, col);
                    eSoldierType soldierType=eSoldierType.None;
                    eSoldierType upSoldierType = IsXUp? eSoldierType.XRegular:eSoldierType.ORegular;
                    eSoldierType downSoldierType = IsXUp ? eSoldierType.ORegular : eSoldierType.XRegular;

                    if (position.IsPositionDescribeBlackSquare())
                    {
                        if (row < playerRows)
                        {
                            
                            soldierType = upSoldierType;
                        }
                        else if (row >= size - playerRows)
                        {
                            soldierType = downSoldierType;
                        }
                    }

                    r_GameBoard[row,col] = new Square(position, soldierType);
                }
            }
        }

        public void InitializeBoard()
        {
            int size = GameBoardSize;
            int playerRows = (size / 2) - 1;
            eSoldierType upSoldierType = IsXUp ? eSoldierType.XRegular : eSoldierType.ORegular;
            eSoldierType downSoldierType = IsXUp ? eSoldierType.ORegular : eSoldierType.XRegular;


            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Position position = new Position(row, col);
                    Square square = GetSquareInPositionWithoutValidationCheck(position);

                    square.SoldierType = eSoldierType.None;
                    
                    if (position.IsPositionDescribeBlackSquare())
                    {
                        if (row < playerRows)
                        {
                            square.SoldierType = upSoldierType;
                        }
                        else if (row >= size - playerRows)
                        {
                            square.SoldierType = downSoldierType;
                        }
                    }
                }
            }
        }

        private void checkAndPromote(Square i_square, Player i_cuurentTurnPlayer)
        {
            if (i_square.IsHoldingKing() == false)
            {
                if (i_square.Position.Row == 0)
                {
                    bool isXUpPromotion = i_cuurentTurnPlayer.GetSoldiersSign == 'X' && IsXUp == false;

                    if (isXUpPromotion == true)
                    {
                        i_square.PromoteSoldier();
                    }
                    else
                    {
                        bool isOUpPromotion = i_cuurentTurnPlayer.GetSoldiersSign == 'O' && IsXUp == true;

                        if (isXUpPromotion == true)
                        {
                            i_square.PromoteSoldier();
                        }
                    }
                }
                else if (i_square.Position.Row == GameBoardSize - 1)
                {
                    bool isXDownPromotion = i_cuurentTurnPlayer.GetSoldiersSign == 'X' && IsXUp == true;

                    if (isXDownPromotion == true)
                    {
                        i_square.PromoteSoldier();
                    }
                    else
                    {
                        bool isOUpPromotion = i_cuurentTurnPlayer.GetSoldiersSign == 'O' && IsXUp == false;

                        if (isOUpPromotion == true)
                        {
                            i_square.PromoteSoldier();
                        }
                    }
                }
            }
        }

        public enum eBoardSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

    }
}
