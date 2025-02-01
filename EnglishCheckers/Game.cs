using EnglishCheckers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    public class Game
    {
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentTurnPlayer;
        private Player m_WaitingPlayer;
        private Player m_LastTurnPlayer;
        private Board m_Board;
        private List<Move> m_PotentialNonEatingMoves;
        private List<Move> m_PotentialEatingMoves;
        private bool m_IsGameFinished=false;
        private bool m_IsGameOn = false;
        private Player m_Winner;
        private string m_LastMove = string.Empty;
               
        public bool SetNewPlayer(string i_PlayerName)
        {
            bool isPlayerinitialized = false;

            if (m_IsGameOn == false)
            {
                if (i_PlayerName.Length < 20 && i_PlayerName.Length > 1)
                {
                    const bool v_isAI = false;

                    if (m_Player2 == null)
                    {
                        m_Player2 = new Player(i_PlayerName, v_isAI, ePlayerSoldiersSign.X);
                        isPlayerinitialized = true;
                    }
                    else if (m_Player1 == null)
                    {
                        if (m_Player2.Name != i_PlayerName)
                        {
                            m_Player1 = new Player(i_PlayerName, v_isAI, ePlayerSoldiersSign.O);
                            isPlayerinitialized = true;
                        }
                    }
                }
            }

            return isPlayerinitialized;
        }

        public bool SetBoard(int i_BoardSize)
        {
            bool isBoardInitialized = false;

            if (m_IsGameOn == false)
            {
                if (i_BoardSize == 10 || i_BoardSize == 8 || i_BoardSize == 6)
                {
                    if (m_Board == null)
                    {
                        Board.eBoardSize boardSize = (Board.eBoardSize)i_BoardSize;

                        m_Board = new Board(boardSize);
                        isBoardInitialized = true;
                    }
                }
            }

            return isBoardInitialized;
        }

        public bool InitializeFirstGame()
        {
            bool isGameInitialized = false;

            if (m_IsGameOn == false)
            {
                if (m_Board != null && m_Player2 != null)
                {
                    if (m_Player1 == null)
                    {
                        string AIPlayerName = "Computer";
                        bool isAI = true;

                        m_Player1 = new Player(AIPlayerName, isAI, ePlayerSoldiersSign.O);
                    }

                    m_CurrentTurnPlayer = m_Player2;
                    m_WaitingPlayer = m_Player1;
                    m_PotentialEatingMoves = new List<Move>();
                    m_PotentialNonEatingMoves = new List<Move>();
                    fillPlayerListOfSoldierHoldingSquares();
                    updatePotentialMoves();
                    m_IsGameOn = true;
                    isGameInitialized = true;
                    }
            }

            return isGameInitialized;
        }

        public bool MakePlayerMove(int i_StartRow, int i_StartColumn, int i_EndRow, int i_EndColumn)
        {
            bool isMoveOccurred = false;

            if (isPlayerTurn()==true)
            {
                Position startPosition = new Position(i_StartRow, i_StartColumn);
                Position endPosition = new Position(i_EndRow, i_EndColumn);
                Square startSquare = m_Board.GetSquareInPosition(startPosition);
                Square endSquare = m_Board.GetSquareInPosition(endPosition);

                if (startSquare != null && endSquare != null)
                {
                    Move move = new Move(startSquare, endSquare);
                    
                    isMoveOccurred = MakeMove(move);
                }
            }
            
            return isMoveOccurred;
        }

        public bool MakeComputerMove()
        {
            bool isMoveOccured = false;

            if (IsComputerTurn())
            {
                List<Move> relevantList = m_PotentialEatingMoves.Count == 0 ? m_PotentialNonEatingMoves : m_PotentialEatingMoves;
                Random random = new Random();
                int moveIndex = random.Next(relevantList.Count);

                isMoveOccured = MakeMove(relevantList[moveIndex]);
            }

            return isMoveOccured;
        }

        private bool MakeMove(Move i_move)
        {
            bool isMoveOccurred = false;

            if (m_CurrentTurnPlayer != null)
            {

                if (m_PotentialEatingMoves.Count > 0)
                {
                    if (isMoveInEatingList(i_move) == true)
                    {
                        m_Board.UpdateEatingMove(i_move, m_CurrentTurnPlayer);
                        m_CurrentTurnPlayer.UpdateHoldingSquareListAfterMove(i_move);
                        Position position = i_move.GetMiddleSquarePositionFromEatingMove();
                        Square Eatedsquare = m_Board.GetSquareInPositionWithoutValidationCheck(position);

                        m_WaitingPlayer.UpdateHoldingSquareListAfterEated(Eatedsquare);
                        updateLastMove(i_move);
                        afterEatingTurnManager(i_move.EndSquare);
                        isMoveOccurred = true;
                    }
                }
                else if (isMoveInNonEatingList(i_move) == true)
                {
                    m_Board.UpdateMove(i_move, m_CurrentTurnPlayer);
                    m_CurrentTurnPlayer.UpdateHoldingSquareListAfterMove(i_move);
                    isMoveOccurred = true;
                    updateLastMove(i_move);
                    switchTurn();
                }
            }

            return isMoveOccurred;
        }

        public bool MakePlayerMove(string i_moveStr)
        {
            bool isMoveOccured = false;

            if (i_moveStr.Length == 5)
            {
                if(i_moveStr[2]=='>')
                {
                    if(Char.IsUpper(i_moveStr[0])==true && Char.IsUpper(i_moveStr[3]) == true)
                    {
                        if(Char.IsLower(i_moveStr[1]) == true && Char.IsLower(i_moveStr[4])==true)
                        {
                            int startRow = i_moveStr[0] - 'A';
                            int startColumn = i_moveStr[1] - 'a';
                            int endRow = i_moveStr[3] - 'A';
                            int endColumn = i_moveStr[4] - 'a';

                            isMoveOccured = MakePlayerMove(startRow, startColumn, endRow, endColumn);
                        }
                    }
                }
            }

            return isMoveOccured;
        }

        public bool InitializeNewGame()
        {
            bool isInitializedNewGame = false;

            if (m_IsGameFinished == true)
            {
                m_IsGameFinished = false;
                m_IsGameOn = true;
                m_LastTurnPlayer = null;
                m_Winner = null;
                m_LastMove = string.Empty;
                m_Board.InitializeBoard();
                m_Player1.CleanSoldiersHoldingSquaresList();
                m_Player2.CleanSoldiersHoldingSquaresList();
                fillPlayerListOfSoldierHoldingSquares();
                m_CurrentTurnPlayer = m_Player2;
                m_WaitingPlayer = m_Player1;
                updatePotentialMoves();
                isInitializedNewGame = true;
            }

            return isInitializedNewGame;
        }

        public bool GetIsGameFinished()
        {
            return m_IsGameFinished;
        }

        public bool Quit()
        {
            bool isQuitOccured = false;

            if (m_CurrentTurnPlayer != null)
            {
                m_Winner = m_WaitingPlayer;
                finishGame();
                isQuitOccured = true;
            }

            return isQuitOccured;
        }

        public string GetFirstPlayerName()
        {
            string name = string.Empty;

            if (m_Player2.Name != null)
            {
                name = m_Player2.Name;
            }

            return name;
        }

        public string GetSecondPlayerName()
        {
            string name = string.Empty;

            if (m_Player1.Name != null)
            {
                name = m_Player1.Name;
            }

            return name;
        }

        public string GetCurrentTurnPlayerName()
        {
            string name = string.Empty;

            if (m_CurrentTurnPlayer.Name != null)
            {
                name = m_CurrentTurnPlayer.Name;
            }

            return name;
        }
    
        public string GetLastTurnPlayerName()
        {
            string name = string.Empty;

            if (m_LastTurnPlayer.Name != null)
            {
                name = m_LastTurnPlayer.Name;
            }

            return name;
        }

        public char GetCurrentTurnPlayerSoldiersSign()
        {
            char sign = 'N';
            if(m_CurrentTurnPlayer!=null)
            {
                sign = m_CurrentTurnPlayer.GetSoldiersSign;
            }
            return sign;
        }

        public char GetLastTurnPlayerSoldiersSign()
        {
            char sign = 'N';
            if (m_LastTurnPlayer != null)
            {
                sign = m_LastTurnPlayer.GetSoldiersSign;
            }
            return sign;
        }

        public int GetBoardSize()
        {
            int size = 0;
            if (m_Board != null)
            {
                size = m_Board.GameBoardSize;
            }
            return size;
        }

        public string GetLastMove()
        {
            return m_LastMove;
        }

        public bool IsComputerTurn()
        {
            bool isComputerTurn = false;

            if (m_CurrentTurnPlayer != null)
            {
                isComputerTurn = m_CurrentTurnPlayer.IsAI;
            }

            return isComputerTurn;
        }

        public char GetSquareSoldierSign(int i_row ,int i_column)
        {
            Position position = new Position(i_row, i_column);
            Square square= m_Board.GetSquareInPosition(position);
            
            return square.GetSquareSoldierSign();
        }
        
        public string GetWinnerName()
        {
            string name = string.Empty;

            if (m_Winner.Name != null)
            {
                name = m_Winner.Name;
            }

            return name;
        }

        public int GetFirstPlayerScore()
        {
            int score = 0;
            if (m_Player2 != null)
            {
                score = m_Player2.Score;
            }
            return score;
        }

        public int GetSecondPlayerScore()
        {
            int score = 0;
            if (m_Player1 != null)
            {
                score = m_Player1.Score;
            }
            return score;
        }

        private bool isPlayerTurn()
        {
            bool isPlayerTurn = false;

            if (m_CurrentTurnPlayer != null)
            {
                isPlayerTurn = m_CurrentTurnPlayer.IsAI==false;
            }

            return isPlayerTurn;
        }

        private void fillPlayerListOfSoldierHoldingSquares()
        {
            int size = GetBoardSize();

            for (int row = 0; row < size; row++)
            {
                for (int column = 0; column < size; column++)
                {
                    Position position = new Position(row, column);
                    Square square = m_Board.GetSquareInPositionWithoutValidationCheck(position);

                    if (square.GetSquareSoldierSign() == m_Player2.GetSoldiersSign)
                    {
                        m_Player2.AddSoldierHoldingSquaretoList(square);
                    }
                    else if (square.GetSquareSoldierSign() == m_Player1.GetSoldiersSign)
                    {
                        m_Player1.AddSoldierHoldingSquaretoList(square);
                    }
                }
            }
        }

        private void updatePotentialMoves()
        {
            m_PotentialNonEatingMoves.Clear();
            m_PotentialEatingMoves.Clear();
            List<Square> soldiersHoldingSquares = m_CurrentTurnPlayer.GetSoldiersHoldingSquares();

            foreach (Square soldiersHoldingSquare in soldiersHoldingSquares)
            {
                addPotentialMovesForSoldierToPotentialMoveLists(soldiersHoldingSquare);
            }
        }

        private void addPotentialMovesForSoldierToPotentialMoveLists(Square i_soldiersHoldingSquare)
        {
            bool isPlayerUp = m_Board.IsXUp == (m_CurrentTurnPlayer.GetSoldiersSign == 'X');
            Direction[] soldierDirections = DirectionManager.GetSoldierDirections(i_soldiersHoldingSquare.SoldierType,isPlayerUp);
            
            foreach (Direction direction in soldierDirections)
            {
                int endSqureRow = i_soldiersHoldingSquare.Position.Row + direction.XDirection;
                int endSquareColumn = i_soldiersHoldingSquare.Position.Column + direction.YDirection;
                Position newPosition = new Position(endSqureRow, endSquareColumn);
                Square targetSquare = m_Board.GetSquareInPosition(newPosition);

                if (targetSquare != null)
                {
                    if (targetSquare.IsSquareEmpty())
                    {                        
                        Move move = new Move(i_soldiersHoldingSquare, targetSquare);
                        
                        m_PotentialNonEatingMoves.Add(move);
                    }
                    else
                    {
                        Square middleSquare = targetSquare;

                        endSqureRow = endSqureRow + direction.XDirection;
                        endSquareColumn = endSquareColumn + direction.YDirection;
                        Position jumpPosition = new Position(endSqureRow, endSquareColumn);
                        targetSquare = m_Board.GetSquareInPosition(jumpPosition);
                        if (targetSquare != null)
                        {
                            if (targetSquare.IsSquareEmpty())
                                if (middleSquare.isOpponentSoldierAtSquare(m_CurrentTurnPlayer))
                                {
                                    Move move = new Move(i_soldiersHoldingSquare, targetSquare);
                                    
                                    m_PotentialEatingMoves.Add(move);
                                }
                        }
                    }
                }
            }
        }

        private bool isMoveInEatingList(Move i_newMove)
        {
            bool isMoveInList = false;

            foreach (Move move in m_PotentialEatingMoves)
            {
                if (i_newMove.Equals(move))
                {
                    isMoveInList = true;
                    break;
                }
            }

            return isMoveInList;
        }

        private bool isMoveInNonEatingList(Move i_newMove)
        {
            bool isMoveInList = false;

            foreach (Move move in m_PotentialNonEatingMoves)
            {
                if (i_newMove.Equals(move))
                {
                    isMoveInList = true;
                    break;
                }
            }

            return isMoveInList;
        }

        private void afterEatingTurnManager(Square i_soldiersHoldingSquare)
        {
            if (canContinueEating(i_soldiersHoldingSquare) == false)
            {
                switchTurn();
            }
            else
            {
                m_LastTurnPlayer = m_CurrentTurnPlayer;
            }
        }

        private void switchTurn()
        {
            switchCurrentTurnPlayer();
            updatePotentialMoves();
            checkIsGameFinished();
        }

        private void finishGame()
        {
            int winnerPoints;

            m_IsGameFinished = true;
            m_IsGameOn = false;
            m_CurrentTurnPlayer= null;
            m_LastTurnPlayer= null;
            if (m_Winner != null)
            {
                winnerPoints = calculateWinnerPoints();
                m_Winner.AddPoints(winnerPoints);
            }
        }

        private void switchCurrentTurnPlayer()
        {
            if (m_CurrentTurnPlayer != null)
            {
                Player tempPlayer = m_WaitingPlayer;

                m_WaitingPlayer = m_CurrentTurnPlayer;
                m_CurrentTurnPlayer = tempPlayer;
                m_LastTurnPlayer = m_WaitingPlayer;
            }
        }
                
        private void checkIsGameFinished()
        {
            if (isCurrentPlayerHasMoves())
            {
                switchCurrentTurnPlayer();
                updatePotentialMoves();
                if (isCurrentPlayerHasMoves() == false)
                {
                    m_Winner = m_CurrentTurnPlayer;
                }

                finishGame();
            }
        }

        private bool isCurrentPlayerHasMoves()
        {
            return m_PotentialEatingMoves.Count == 0 && m_PotentialNonEatingMoves.Count == 0;
        }

        private bool canContinueEating(Square i_soldiersHoldingSquare)
        {
            bool canContinueEating = false;

            m_PotentialNonEatingMoves.Clear();
            m_PotentialEatingMoves.Clear();
            addPotentialMovesForSoldierToPotentialEatingMoveList(i_soldiersHoldingSquare);
            if (m_PotentialEatingMoves.Count > 0)
            {
                canContinueEating = true;
            }

            return canContinueEating;
        }

        private void addPotentialMovesForSoldierToPotentialEatingMoveList(Square i_soldiersHoldingSquare)
        {
            bool isPlayerUp = m_Board.IsXUp == (m_CurrentTurnPlayer.GetSoldiersSign == 'X');
            Direction[] soldierDirections = DirectionManager.GetSoldierDirections(i_soldiersHoldingSquare.SoldierType,isPlayerUp);

            foreach (Direction direction in soldierDirections)
            {
                int squreRow = i_soldiersHoldingSquare.Position.Row + direction.XDirection;
                int squareColumn = i_soldiersHoldingSquare.Position.Column + direction.YDirection;
                Position position = new Position(squreRow, squareColumn);
                Square middleSquare = m_Board.GetSquareInPosition(position);

                if (middleSquare != null)
                {
                    if (middleSquare.isOpponentSoldierAtSquare(m_CurrentTurnPlayer))
                    {
                        squreRow = squreRow + direction.XDirection;
                        squareColumn = squareColumn + direction.YDirection;
                        position = new Position(squreRow, squareColumn);
                        Square targetSquare = m_Board.GetSquareInPosition(position);
                        if (targetSquare != null)
                        {
                            if (targetSquare.IsSquareEmpty())
                            {
                                Move move = new Move(i_soldiersHoldingSquare, targetSquare/*, isJump*/);
                                m_PotentialEatingMoves.Add(move);
                            }
                        }
                    }
                }
            }
        }

        private int calculateWinnerPoints()
        {
            int winnerPoints;
            int minPoints = 4;
            int Player1SoldiersPoints = m_Player1.CalculatePlayerSoldiersPoints();
            int Player2SoldiersPoints = m_Player2.CalculatePlayerSoldiersPoints();

            if (m_Winner == m_Player1)
            {
                winnerPoints = Math.Max(minPoints, Player1SoldiersPoints - Player2SoldiersPoints);
            }
            else
            {
                winnerPoints = Math.Max(minPoints, Player2SoldiersPoints - Player1SoldiersPoints);
            }

            return winnerPoints;
        }

        private void updateLastMove(Move i_move)
        {
            m_LastMove = $"{(char)(i_move.StartSquare.Position.Row + 'A')}{(char)(i_move.StartSquare.Position.Column + 'a')}>{(char)(i_move.EndSquare.Position.Row + 'A')}{(char)(i_move.EndSquare.Position.Column + 'a')}";
        }


    }
}
