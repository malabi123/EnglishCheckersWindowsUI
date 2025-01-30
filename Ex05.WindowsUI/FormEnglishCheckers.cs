using System;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public class FormEnglishCheckers : Form
    {
        private Label label1;
        private Label label2;
        private Label m_LablePlayer1Score;
        private Label m_LablePlayer2Score;

        public FormEnglishCheckers() 
        {
           
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_LablePlayer1Score = new System.Windows.Forms.Label();
            this.m_LablePlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 2:";
            // 
            // m_LablePlayer1Score
            // 
            this.m_LablePlayer1Score.AutoSize = true;
            this.m_LablePlayer1Score.Location = new System.Drawing.Point(128, 29);
            this.m_LablePlayer1Score.Name = "m_LablePlayer1Score";
            this.m_LablePlayer1Score.Size = new System.Drawing.Size(18, 20);
            this.m_LablePlayer1Score.TabIndex = 2;
            this.m_LablePlayer1Score.Text = "0";
            // 
            // m_LablePlayer2Score
            // 
            this.m_LablePlayer2Score.AutoSize = true;
            this.m_LablePlayer2Score.Location = new System.Drawing.Point(386, 29);
            this.m_LablePlayer2Score.Name = "m_LablePlayer2Score";
            this.m_LablePlayer2Score.Size = new System.Drawing.Size(18, 20);
            this.m_LablePlayer2Score.TabIndex = 3;
            this.m_LablePlayer2Score.Text = "0";
            // 
            // FormEnglishCheckers
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(561, 575);
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
