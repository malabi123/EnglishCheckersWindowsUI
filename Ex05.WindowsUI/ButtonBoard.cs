using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    internal class ButtonBoard : Control
    {
        private ButtonSquare[,] m_Board;
        public event Action<object, EventArgs> ButtonSquare_Click;
        
        public ButtonBoard(int i_Size)
        {
            int topLocation = 0;

            for (int i = 0; i < i_Size; i++)
            {
                int leftLocation = 0;

                for (int j = 0; j < i_Size; j++)
                {
                    m_Board[i, j] = new ButtonSquare(i, j);
                    m_Board[i, j].Size = new Size(30, 30);
                    m_Board[i, j].Top = topLocation;
                    m_Board[i, j].Left = leftLocation;

                    if (IsPlaybleButton(i, j))
                    {
                        m_Board[i,j].BackColor = Color.White;
                        m_Board[i, j].Click += ButtonSquareBoard_Click;
                    }
                    else
                    {
                        m_Board[i, j].BackColor = Color.Gray;
                        m_Board[i, j].Enabled = false;
                    }

                    this.Controls.Add(m_Board[i, j]);
                    leftLocation += m_Board[i, j].Size.Width;
                }

                topLocation += m_Board[i, 0].Size.Height;
            }
        }

        private void ButtonSquareBoard_Click(object sender, EventArgs e)
        {
            ButtonSquare_Click?.Invoke(this, e);
        }

        private bool IsPlaybleButton(int i_Row, int i_Column )
        {
            return (i_Row + i_Column) % 2 != 0;
        }
    }
}