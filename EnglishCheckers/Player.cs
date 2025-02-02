using System.Collections.Generic;

namespace EnglishCheckers
{
    internal class Player
    {
        private readonly string r_Name;
        private int m_Score = 0;
        public bool IsAI { get; } = false;
        private List<Square> m_SoldiersHoldingSquares;
        private readonly ePlayerSoldiersSign r_SoldiersSign;

        public Player(string i_Name, bool i_IsAL, ePlayerSoldiersSign i_SoldiersSign)
        {
            r_Name = i_Name;
            IsAI = i_IsAL;
            m_SoldiersHoldingSquares = new List<Square>();
            r_SoldiersSign = i_SoldiersSign;
        }

        internal string Name
        {
            get
            {
                return r_Name;
            }
        }

        internal int Score
        {
            get
            {
                return m_Score;
            }
        }

        internal char GetSoldiersSign
        {
            get
            {
                return (char)r_SoldiersSign;
            }
        }

        internal void AddPoints(int i_Points)
        {
            m_Score += i_Points;
        }

        internal void AddSoldierHoldingSquaretoList(Square i_Square)
        {
            m_SoldiersHoldingSquares.Add(i_Square);
        }

        internal void CleanSoldiersHoldingSquaresList()
        {
            m_SoldiersHoldingSquares.Clear();
        }

        internal List<Square> GetSoldiersHoldingSquares()
        {
            return m_SoldiersHoldingSquares;
        }

        internal int CalculatePlayerSoldiersPoints()
        {
            int sumPoints = 0;

            foreach (Square holdingSoldierSquare in m_SoldiersHoldingSquares)
            {
                sumPoints += holdingSoldierSquare.GetSoldierPoints();
            }

            return sumPoints;
        }

        internal void UpdateHoldingSquareListAfterMove(Move i_Move)
        {
            m_SoldiersHoldingSquares.Remove(i_Move.StartSquare);
            m_SoldiersHoldingSquares.Add(i_Move.EndSquare);
        }

        internal void UpdateHoldingSquareListAfterEated(Square i_Square)
        {
            m_SoldiersHoldingSquares.Remove(i_Square);
        }
    }
}