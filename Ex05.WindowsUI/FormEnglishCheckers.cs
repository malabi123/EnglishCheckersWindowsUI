using EnglishCheckers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public class FormEnglishCheckers : Form
    {
        private Label label1;
        private Label label2;
        private Label m_LablePlayer1Score;
        private Label m_LablePlayer2Score;
        private Game m_game;
        private ButtonBoard m_buttonBoard;

        public FormEnglishCheckers(Game i_game) 
        {
            InitializeComponent(i_game);
        }

        private void InitializeComponent(Game i_game)
        {
            this.m_game = i_game;

            this.m_buttonBoard = new ButtonBoard(m_game.GetBoardSize());
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_LablePlayer1Score = new System.Windows.Forms.Label();
            this.m_LablePlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonBoard
            // 
            this.Controls.Add(this.m_buttonBoard);
            this.m_buttonBoard.Top = 30;
            this.m_buttonBoard.Left = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Name = "label1";
            this.label1.Text = string.Format("{0}:", this.m_game.GetFirstPlayerName());            
            // 
            // m_LablePlayer1Score
            // 
            this.m_LablePlayer1Score.AutoSize = true;
            this.m_LablePlayer1Score.Name = "m_LablePlayer1Score";
            this.m_LablePlayer1Score.Text = "0";
            // 
            // m_LablePlayer2Score
            // 
            this.m_LablePlayer2Score.Name = "m_LablePlayer2Score";
            this.m_LablePlayer2Score.Text = "0";
            this.m_LablePlayer2Score.AutoSize = true;
            // 
            // label2
            //            
            this.label2.Text = string.Format("{0}:", this.m_game.GetSecondPlayerName());
            this.label2.AutoSize = true;
            this.label2.Name = "label2";

            // 
            // FormEnglishCheckers
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize =new System.Drawing.Size(this.m_buttonBoard.Right + 10,this.m_buttonBoard.Bottom+10);
            this.Controls.Add(this.m_buttonBoard);
            this.Controls.Add(this.m_LablePlayer2Score);
            this.Controls.Add(this.m_LablePlayer1Score);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            updateLabelsPositions();
            this.Name = "FormEnglishCheckers";
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void updateLabelsPositions()
        {
            label1.Top = this.m_buttonBoard.Top - 20;
            label1.Left = this.m_buttonBoard.Left + 20;

            m_LablePlayer1Score.Top = label1.Top;
            m_LablePlayer1Score.Left = label1.Right + 5;

            label2.Top = label1.Top;
            label2.Left = this.m_buttonBoard.Right - label2.Width - 30;

            m_LablePlayer2Score.Top = label1.Top;
            m_LablePlayer2Score.Left = label2.Right + 5;
        }
       
    }
}
