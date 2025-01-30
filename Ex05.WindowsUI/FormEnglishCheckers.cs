using EnglishCheckers;
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
            this.label1.Location = new System.Drawing.Point(m_buttonBoard.Left+10, m_buttonBoard.Top - 20);
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text = string.Format("{0}:", this.m_game.GetFirstPlayerName());            
            // 
            // m_LablePlayer1Score
            // 
            this.m_LablePlayer1Score.AutoSize = true;
            this.m_LablePlayer1Score.Location = new System.Drawing.Point(label1.Right + 10, label1.Top);
            this.m_LablePlayer1Score.Name = "m_LablePlayer1Score";
            this.m_LablePlayer1Score.TabIndex = 2;
            this.m_LablePlayer1Score.Text = "0";
            // 
            // m_LablePlayer2Score
            // 
            this.m_LablePlayer2Score.Name = "m_LablePlayer2Score";
            this.m_LablePlayer2Score.TabIndex = 3;
            this.m_LablePlayer2Score.Text = "0";
            this.m_LablePlayer2Score.AutoSize = true;
            this.m_LablePlayer2Score.Location = new System.Drawing.Point(m_buttonBoard.Right - 10 - m_LablePlayer2Score.Width,
                                                                         label1.Top);
            // 
            // label2
            //            
            this.label2.BackColor = Color.AliceBlue;
            this.label2.Text = string.Format("{0}:", this.m_game.GetSecondPlayerName());
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(m_LablePlayer2Score.Left - 10 - label2.Width,
                                                            m_LablePlayer2Score.Top);
            this.label2.Name = "label2";
            this.label2.TabIndex = 1;

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
            this.Name = "FormEnglishCheckers";
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
