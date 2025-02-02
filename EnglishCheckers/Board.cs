namespace EnglishCheckers
{
    internal class Board
    {
        private readonly Square[,] r_GameBoard;
        private readonly eBoardSize r_GameBoardSize;
        private readonly bool r_IsXSoldiersIsUpBoard = false;

        public Board(eBoardSize i_Size)
        {
            r_GameBoardSize = i_Size;
            r_GameBoard = new Square[GameBoardSize, GameBoardSize];
            r_IsXSoldiersIsUpBoard = false;

            initializeSquaresAndBoard();
        }

        internal int GameBoardSize
        {
            get
            {
                return (int)r_GameBoardSize;
            }
        }

        internal bool IsXSoldiersIsUpBoard
        {
            get
            {
                return r_IsXSoldiersIsUpBoard;
            }
        }

        internal void UpdateMove(Move i_Move, Player i_CurrentTurnPlayer)
        {
            i_Move.EndSquare.SoldierType = i_Move.StartSquare.SoldierType;
            i_Move.StartSquare.SoldierReset();
            checkAndPromote(i_Move.EndSquare, i_CurrentTurnPlayer);
        }

        internal void UpdateEatingMove(Move i_Move, Player i_CurrentTurnPlayer)
        {
            Position middleSquarePosition = i_Move.GetMiddleSquarePositionFromEatingMove();
            Square middleSquare = GetSquareInPositionWithoutValidationCheck(middleSquarePosition);

            middleSquare.SoldierReset();
            UpdateMove(i_Move, i_CurrentTurnPlayer);
        }

        internal Square GetSquareInPosition(Position i_Position)
        {
            Square square = null;

            if (IsPositionOnBoard(i_Position))
            {
                square = r_GameBoard[i_Position.Row, i_Position.Column];
            }

            return square;
        }

        internal Square GetSquareInPositionWithoutValidationCheck(Position i_Position)
        {
            return r_GameBoard[i_Position.Row, i_Position.Column]; ;
        }

        internal bool IsPositionOnBoard(Position i_Position)
        {
            int row = i_Position.Row;
            int col = i_Position.Column;

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
                    eSoldierType soldierType = eSoldierType.None;
                    eSoldierType upSoldierType = IsXSoldiersIsUpBoard ? eSoldierType.XRegular : eSoldierType.ORegular;
                    eSoldierType downSoldierType = IsXSoldiersIsUpBoard ? eSoldierType.ORegular : eSoldierType.XRegular;

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

                    r_GameBoard[row, col] = new Square(position, soldierType);
                }
            }
        }

        internal void InitializeBoard()
        {
            int size = GameBoardSize;
            int playerRows = (size / 2) - 1;
            eSoldierType upSoldierType = IsXSoldiersIsUpBoard ? eSoldierType.XRegular : eSoldierType.ORegular;
            eSoldierType downSoldierType = IsXSoldiersIsUpBoard ? eSoldierType.ORegular : eSoldierType.XRegular;

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

        private void checkAndPromote(Square i_Square, Player i_CurrentTurnPlayer)
        {
            if (i_Square.IsHoldingKing() == false)
            {
                if (i_Square.Position.Row == 0)
                {
                    bool isXUpPromotion = i_CurrentTurnPlayer.GetSoldiersSign == 'X' && IsXSoldiersIsUpBoard == false;

                    if (isXUpPromotion == true)
                    {
                        i_Square.PromoteSoldier();
                    }
                    else
                    {
                        bool isOUpPromotion = i_CurrentTurnPlayer.GetSoldiersSign == 'O' && IsXSoldiersIsUpBoard == true;

                        if (isXUpPromotion == true)
                        {
                            i_Square.PromoteSoldier();
                        }
                    }
                }
                else if (i_Square.Position.Row == GameBoardSize - 1)
                {
                    bool isXDownPromotion = i_CurrentTurnPlayer.GetSoldiersSign == 'X' && IsXSoldiersIsUpBoard == true;

                    if (isXDownPromotion == true)
                    {
                        i_Square.PromoteSoldier();
                    }
                    else
                    {
                        bool isOUpPromotion = i_CurrentTurnPlayer.GetSoldiersSign == 'O' && IsXSoldiersIsUpBoard == false;

                        if (isOUpPromotion == true)
                        {
                            i_Square.PromoteSoldier();
                        }
                    }
                }
            }
        }

        internal enum eBoardSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }
    }
}