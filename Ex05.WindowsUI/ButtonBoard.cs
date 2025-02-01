using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    internal class ButtonBoard : UserControl
    {
        private ButtonSquare[,] m_Board;
        public event Action<object, EventArgs> ButtonSquare_Click;
        
        public ButtonBoard(int i_Size)
        {
            InitializeComponent(i_Size);
        }

        private void InitializeComponent(int i_Size)
        {
            m_Board = new ButtonSquare[i_Size, i_Size];

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
                        m_Board[i, j].BackColor = Color.White;
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

            this.Size = new Size(m_Board[0, 0].Height * i_Size, m_Board[0, 0].Width * i_Size);
        }

        private void ButtonSquareBoard_Click(object sender, EventArgs e)
        {
            ButtonSquare_Click?.Invoke(sender, e);
        }

        private bool IsPlaybleButton(int i_Row, int i_Column )
        {
            return (i_Row + i_Column) % 2 != 0;
        }

        public void ChangeButtonSquareText(int i_Row, int i_Column, string i_newText)
        {
            m_Board[i_Row,i_Column].Text = i_newText;
        }
    }
}