using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishCheckers
{
    internal class Player
    {


        private readonly string r_Name;
        private int m_Score = 0;
        public bool IsAI { get; } = false;
        private List<Square> m_soldiersHoldingSquares;
        private readonly ePlayerSoldiersSign r_SoldiersSign;

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
        }

        public char GetSoldiersSign
        {
            get { return (char)r_SoldiersSign; }
        }

        public Player(string i_name, bool i_isAL,ePlayerSoldiersSign i_SoldiersSign)
        {
            r_Name = i_name;
            IsAI = i_isAL;
            m_soldiersHoldingSquares = new List<Square>();
            r_SoldiersSign = i_SoldiersSign;
        }

        public void AddPoints(int points)
        {
            m_Score += points;
        }

        public void AddSoldierHoldingSquaretoList(Square square)
        {
            m_soldiersHoldingSquares.Add(square);
        }

        public void CleanSoldiersHoldingSquaresList()
        {
            m_soldiersHoldingSquares.Clear();
        }

        public List<Square> GetSoldiersHoldingSquares() 
        {  
            return m_soldiersHoldingSquares;
        }

        public int CalculatePlayerSoldiersPoints()
        {
            int sumPoints = 0;

            foreach (Square holdingSoldierSquare in m_soldiersHoldingSquares)
            {
                sumPoints += holdingSoldierSquare.GetSoldierPoints();
            }

            return sumPoints;
        }

        public void UpdateHoldingSquareListAfterMove(Move i_move)
        {
            m_soldiersHoldingSquares.Remove(i_move.StartSquare);
            m_soldiersHoldingSquares.Add(i_move.EndSquare);
        }

        public void UpdateHoldingSquareListAfterEated(Square i_square)
        {
            m_soldiersHoldingSquares.Remove(i_square);
        }
    }
}

