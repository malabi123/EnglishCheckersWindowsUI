using EnglishCheckers;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public class FormEnglishCheckers : Form
    {
        private Label m_LabelPlayer1Name;
        private Label m_LabelPlayer2Name;
        private Label m_LablePlayer1Score;
        private Label m_LablePlayer2Score;
        private Game m_Game;
        private ButtonBoard m_ButtonBoard;
        private ButtonSquare m_ButtonSquareLastClicked = null;
        private Timer m_Timer;

        public FormEnglishCheckers(Game i_Game)
        {
            InitializeComponent(i_Game);
            updateBoard();
        }

        private void updateBoard()
        {
            string soldierSign;

            for (int i = 0; i < m_Game.GetBoardSize(); i++)
            {
                for (int j = 0; j < m_Game.GetBoardSize(); j++)
                {
                    soldierSign = m_Game.GetSquareSoldierSign(i, j).ToString();
                    m_ButtonBoard.ChangeButtonSquareText(i, j, soldierSign);
                }
            }
        }

        private void InitializeComponent(Game i_Game)
        {
            // 
            // m_Game
            //
            this.m_Game = i_Game;
            this.m_Game.InitializeFirstGame();

            this.m_ButtonBoard = new ButtonBoard(m_Game.GetBoardSize());
            this.m_LabelPlayer1Name = new System.Windows.Forms.Label();
            this.m_LabelPlayer2Name = new System.Windows.Forms.Label();
            this.m_LablePlayer1Score = new System.Windows.Forms.Label();
            this.m_LablePlayer2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_Timer
            //
            if (this.m_Game.GetIsPlayingWithComputer())
            {
                this.m_Timer = new Timer();
                m_Timer.Interval = 1500;
                m_Timer.Tick += Timer_Tick;
            }
            // 
            // m_ButtonBoard
            // 
            this.m_ButtonBoard.Top = 30;
            this.m_ButtonBoard.Left = 10;
            this.m_ButtonBoard.ButtonSquare_Click += this.buttonSquare_OnClick;
            // 
            // m_LabelPlayer1Name
            // 
            this.m_LabelPlayer1Name.AutoSize = true;
            this.m_LabelPlayer1Name.Name = "m_LabelPlayer1Name";
            this.m_LabelPlayer1Name.Text = string.Format("{0}:", this.m_Game.GetFirstPlayerName());
            this.m_LabelPlayer1Name.Font = new Font("Tahoma", 10, FontStyle.Bold);
            // 
            // m_LablePlayer1Score
            // 
            this.m_LablePlayer1Score.AutoSize = true;
            this.m_LablePlayer1Score.Name = "m_LablePlayer1Score";
            this.m_LablePlayer1Score.Text = "0";
            this.m_LablePlayer1Score.Font = new Font("Tahoma", 10, FontStyle.Bold);
            // 
            // m_LablePlayer2Score
            // 
            this.m_LablePlayer2Score.AutoSize = true;
            this.m_LablePlayer2Score.Name = "m_LablePlayer2Score";
            this.m_LablePlayer2Score.Text = "0";
            this.m_LablePlayer2Score.Font = new Font("Tahoma", 10, FontStyle.Bold);
            // 
            // m_LabelPlayer2Name
            //            
            this.m_LabelPlayer2Name.Text = string.Format("{0}:", this.m_Game.GetSecondPlayerName());
            this.m_LabelPlayer2Name.AutoSize = true;
            this.m_LabelPlayer2Name.Name = "m_LabelPlayer2Name";
            this.m_LabelPlayer2Name.Font = new Font("Tahoma", 10, FontStyle.Bold);
            // 
            // FormEnglishCheckers
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(this.m_ButtonBoard.Right + 10, this.m_ButtonBoard.Bottom + 10);
            this.Controls.Add(this.m_ButtonBoard);
            this.Controls.Add(this.m_LablePlayer2Score);
            this.Controls.Add(this.m_LablePlayer1Score);
            this.Controls.Add(this.m_LabelPlayer2Name);
            this.Controls.Add(this.m_LabelPlayer1Name);

            updateLabelsPositions();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "FormEnglishCheckers";
            this.Text = "Damka";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void updateLabelsPositions()
        {
            m_LabelPlayer1Name.Top = this.m_ButtonBoard.Top - 20;
            m_LabelPlayer1Name.Left = this.m_ButtonBoard.Left + 20;

            m_LablePlayer1Score.Top = m_LabelPlayer1Name.Top;
            m_LablePlayer1Score.Left = m_LabelPlayer1Name.Right + 3;

            m_LabelPlayer2Name.Top = m_LabelPlayer1Name.Top;
            m_LabelPlayer2Name.Left = this.m_ButtonBoard.Right - m_LabelPlayer2Name.Width - 30;

            m_LablePlayer2Score.Top = m_LabelPlayer1Name.Top;
            m_LablePlayer2Score.Left = m_LabelPlayer2Name.Right + 3;
        }

        private void buttonSquare_OnClick(object sender, EventArgs e)
        {
            if (m_Timer.Enabled == false)
            {
                ButtonSquare buttonSquare = sender as ButtonSquare;
                string noSoldierString = " ";

                if (m_ButtonSquareLastClicked == null)
                {
                    if (buttonSquare.Text != noSoldierString)
                    {
                        m_ButtonSquareLastClicked = buttonSquare;
                        buttonSquare.BackColor = Color.Aqua;
                    }
                }
                else
                {
                    if (m_ButtonSquareLastClicked == buttonSquare)
                    {
                        buttonSquare.BackColor = Color.White;
                        m_ButtonSquareLastClicked = null;
                    }
                    else
                    {
                        if (buttonSquare.Text == noSoldierString)
                        {
                            if (tryMove(buttonSquare))
                            {
                                updateBoard();
                                m_ButtonSquareLastClicked.BackColor = Color.White;
                                m_ButtonSquareLastClicked = null;

                                if (!checkAndUpdateGameEnd())
                                {
                                    tryComputerMove();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid Move!");
                            }
                        }
                    }
                }
            }
        }

        private bool tryMove(ButtonSquare i_ButtonSquare)
        {
            return m_Game.MakePlayerMove(m_ButtonSquareLastClicked.Row, m_ButtonSquareLastClicked.Column,
                                  i_ButtonSquare.Row, i_ButtonSquare.Column);
        }

        private void tryComputerMove()
        {
            bool isMoveOccured = m_Game.MakeComputerMove();

            if (isMoveOccured)
            {
                m_Timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            m_Timer.Stop();
            updateBoard();
            tryComputerMove();
        }

        private bool checkAndUpdateGameEnd()
        {
            bool isGameEnd = m_Game.GetIsGameFinished();

            if (isGameEnd)
            {
                StringBuilder endGameMessage = new StringBuilder();

                string winnerName = m_Game.GetWinnerName();
                DialogResult result;
                const string k_DamkaStr = "Damka";

                if (winnerName != string.Empty)
                {
                    endGameMessage.Append(winnerName);
                    endGameMessage.AppendLine(" Won!");
                }
                else
                {
                    endGameMessage.AppendLine("Tie!");
                }

                endGameMessage.Append("Another Round?");
                result = MessageBox.Show(endGameMessage.ToString(), k_DamkaStr, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    startNewgGameAndUpdateResult(winnerName);
                }
                else
                {
                    if (result == DialogResult.No || result == DialogResult.Cancel)
                        this.Close();
                }
            }

            return isGameEnd;
        }

        private void startNewgGameAndUpdateResult(string i_WinnerName)
        {
            i_WinnerName = string.Format("{0}:", i_WinnerName);

            if (i_WinnerName == m_LabelPlayer1Name.Text)
            {
                m_LablePlayer1Score.Text = m_Game.GetFirstPlayerScore().ToString();
            }

            if (i_WinnerName == m_LabelPlayer2Name.Text)
            {
                m_LablePlayer2Score.Text = m_Game.GetSecondPlayerScore().ToString();
            }

            m_Game.InitializeNewGame();
            updateBoard();
        }
    }
}