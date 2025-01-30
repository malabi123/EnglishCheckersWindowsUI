using EnglishCheckers;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    internal class FormGameSettings : Form
    {
        private Label m_labelBoardSize;
        private Label m_labePlayers;
        private Label m_labelPlayer1;
        private CheckBox m_checkBoxPlayer2;
        private RadioButton m_radioButtonSize6;
        private RadioButton m_radioButtonSize8;
        private RadioButton m_radioButtonSize10;
        private TextBox m_textBoxPlayer1Name;
        private TextBox m_textBoxPlayer2Name;
        private Button m_buttonDone;

        public string Player1Name
        {
            get
            {
                string name = string.Empty;
                
                if (m_textBoxPlayer1Name != null)
                {
                    name = m_textBoxPlayer1Name.Text;
                }

                return name;
            }
        }

        public bool IsTwoPlayers
        {
            get
            {
                bool isTwoPlayers = false;
                {
                    if (m_checkBoxPlayer2 != null)
                    {
                        isTwoPlayers = m_checkBoxPlayer2.Checked;
                    }
                }

                return isTwoPlayers;
            }
        }

        public FormGameSettings( Game i_Game)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.m_labelBoardSize = new System.Windows.Forms.Label();
            this.m_labePlayers = new System.Windows.Forms.Label();
            this.m_radioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.m_labelPlayer1 = new System.Windows.Forms.Label();
            this.m_checkBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_radioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.m_radioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.m_textBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.m_textBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.m_buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_labelBoardSize
            // 
            this.m_labelBoardSize.AutoSize = true;
            this.m_labelBoardSize.BackColor = System.Drawing.Color.Transparent;
            this.m_labelBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_labelBoardSize.Location = new System.Drawing.Point(12, 9);
            this.m_labelBoardSize.Name = "m_labelBoardSize";
            this.m_labelBoardSize.Size = new System.Drawing.Size(97, 20);
            this.m_labelBoardSize.TabIndex = 0;
            this.m_labelBoardSize.Text = "Board Size:";
            // 
            // m_labePlayers
            // 
            this.m_labePlayers.AutoSize = true;
            this.m_labePlayers.BackColor = System.Drawing.Color.Transparent;
            this.m_labePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_labePlayers.Location = new System.Drawing.Point(12, 70);
            this.m_labePlayers.Name = "m_labePlayers";
            this.m_labePlayers.Size = new System.Drawing.Size(70, 20);
            this.m_labePlayers.TabIndex = 4;
            this.m_labePlayers.Text = "Players:";
            // 
            // m_radioButtonSize6
            // 
            this.m_radioButtonSize6.AutoSize = true;
            this.m_radioButtonSize6.BackColor = System.Drawing.Color.Transparent;
            this.m_radioButtonSize6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_radioButtonSize6.Location = new System.Drawing.Point(28, 39);
            this.m_radioButtonSize6.Name = "m_radioButtonSize6";
            this.m_radioButtonSize6.Size = new System.Drawing.Size(56, 24);
            this.m_radioButtonSize6.TabIndex = 1;
            this.m_radioButtonSize6.Text = "6x6";
            this.m_radioButtonSize6.UseVisualStyleBackColor = false;
            // 
            // m_labelPlayer1
            // 
            this.m_labelPlayer1.AutoSize = true;
            this.m_labelPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.m_labelPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_labelPlayer1.Location = new System.Drawing.Point(24, 100);
            this.m_labelPlayer1.Name = "m_labelPlayer1";
            this.m_labelPlayer1.Size = new System.Drawing.Size(75, 20);
            this.m_labelPlayer1.TabIndex = 5;
            this.m_labelPlayer1.Text = "Player 1:";
            // 
            // m_checkBoxPlayer2
            // 
            this.m_checkBoxPlayer2.AutoSize = true;
            this.m_checkBoxPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_checkBoxPlayer2.Location = new System.Drawing.Point(28, 131);
            this.m_checkBoxPlayer2.Name = "m_checkBoxPlayer2";
            this.m_checkBoxPlayer2.Size = new System.Drawing.Size(97, 24);
            this.m_checkBoxPlayer2.TabIndex = 7;
            this.m_checkBoxPlayer2.Text = "Player 2:";
            this.m_checkBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_checkBoxPlayer2_CheckedChanged);
            // 
            // m_radioButtonSize8
            // 
            this.m_radioButtonSize8.AutoSize = true;
            this.m_radioButtonSize8.BackColor = System.Drawing.Color.Transparent;
            this.m_radioButtonSize8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_radioButtonSize8.Location = new System.Drawing.Point(124, 39);
            this.m_radioButtonSize8.Name = "m_radioButtonSize8";
            this.m_radioButtonSize8.Size = new System.Drawing.Size(56, 24);
            this.m_radioButtonSize8.TabIndex = 2;
            this.m_radioButtonSize8.Text = "8x8";
            this.m_radioButtonSize8.UseVisualStyleBackColor = false;
            // 
            // m_radioButtonSize10
            // 
            this.m_radioButtonSize10.AutoSize = true;
            this.m_radioButtonSize10.BackColor = System.Drawing.Color.Transparent;
            this.m_radioButtonSize10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_radioButtonSize10.Location = new System.Drawing.Point(216, 39);
            this.m_radioButtonSize10.Name = "m_radioButtonSize10";
            this.m_radioButtonSize10.Size = new System.Drawing.Size(74, 24);
            this.m_radioButtonSize10.TabIndex = 3;
            this.m_radioButtonSize10.Text = "10x10";
            this.m_radioButtonSize10.UseVisualStyleBackColor = false;
            // 
            // m_textBoxPlayer1Name
            // 
            this.m_textBoxPlayer1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_textBoxPlayer1Name.Location = new System.Drawing.Point(168, 97);
            this.m_textBoxPlayer1Name.MaxLength = 20;
            this.m_textBoxPlayer1Name.Name = "m_textBoxPlayer1Name";
            this.m_textBoxPlayer1Name.Size = new System.Drawing.Size(122, 26);
            this.m_textBoxPlayer1Name.TabIndex = 8;
            // 
            // m_textBoxPlayer2Name
            // 
            this.m_textBoxPlayer2Name.Enabled = false;
            this.m_textBoxPlayer2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_textBoxPlayer2Name.Location = new System.Drawing.Point(168, 129);
            this.m_textBoxPlayer2Name.MaxLength = 20;
            this.m_textBoxPlayer2Name.Name = "m_textBoxPlayer2Name";
            this.m_textBoxPlayer2Name.Size = new System.Drawing.Size(122, 26);
            this.m_textBoxPlayer2Name.TabIndex = 9;
            this.m_textBoxPlayer2Name.Text = "[Computer]";
            // 
            // m_buttonDone
            // 
            this.m_buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.m_buttonDone.Location = new System.Drawing.Point(197, 160);
            this.m_buttonDone.Name = "m_buttonDone";
            this.m_buttonDone.Size = new System.Drawing.Size(93, 33);
            this.m_buttonDone.TabIndex = 10;
            this.m_buttonDone.Text = "Done";
            this.m_buttonDone.Click += new System.EventHandler(this.m_buttonDone_Click);
            // 
            // FormGameSettings
            // 
            this.ClientSize = new System.Drawing.Size(302, 205);
            this.Controls.Add(this.m_labelBoardSize);
            this.Controls.Add(this.m_radioButtonSize6);
            this.Controls.Add(this.m_radioButtonSize8);
            this.Controls.Add(this.m_radioButtonSize10);
            this.Controls.Add(this.m_labePlayers);
            this.Controls.Add(this.m_labelPlayer1);
            this.Controls.Add(this.m_checkBoxPlayer2);
            this.Controls.Add(this.m_textBoxPlayer1Name);
            this.Controls.Add(this.m_textBoxPlayer2Name);
            this.Controls.Add(this.m_buttonDone);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void m_checkBoxPlayer2_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox.Checked)
            {
                m_textBoxPlayer2Name.Enabled = true;
                m_textBoxPlayer2Name.Text = string.Empty;
            }
            else
            {
                m_textBoxPlayer2Name.Enabled = false;
                m_textBoxPlayer2Name.Text = "[Computer]";
            }
        }

        private void m_buttonDone_Click(object sender, System.EventArgs e)
        {
            if (isValidInput())
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Unvalid input please try again");
            }
        }

        private bool isValidInput()
        {
            bool isValidInput = false;

            if (m_textBoxPlayer1Name.Text.Length >= 2)
            {
                if (m_textBoxPlayer2Name.Text.Length >= 2)
                {
                    if (m_radioButtonSize6.Checked ||
                       m_radioButtonSize8.Checked ||
                       m_radioButtonSize10.Checked)
                    {
                        if (!isPlayersHaveSameName())
                        {
                            isValidInput = true;
                        }
                    }
                }
            }

            return isValidInput;
        }

        private bool isPlayersHaveSameName()
        {
            return (m_checkBoxPlayer2.Checked && 
                    m_textBoxPlayer1Name.Text==m_textBoxPlayer2Name.Text);
        }
    }
}