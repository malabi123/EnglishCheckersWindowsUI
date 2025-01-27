using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    internal class FormGameSettings : Form
    {
        public FormGameSettings() 
        {
            Label labelBoardSize = new Label();
            Label labePlayers = new Label();
            Label labelPlayer1 = new Label();
            Label labelPlayer2 = new Label();

            CheckBox checkBoxPlayer2 = new CheckBox();

            const int v_Size6 = 6;
            const int v_Size8 = 8;
            const int v_Size10 = 10;

            RadioButton radioButtonSize6 = new RadioButton();
            RadioButton radioButtonSize8 = new RadioButton();    
            RadioButton radioButtonSize10= new RadioButton();

            TextBox textBoxPlayer1Name = new TextBox();
            TextBox textBoxPlayer2Name = new TextBox();

            Button buttonDone = new Button();

            this.Controls.Add(labelBoardSize);
            this.Controls.Add(radioButtonSize6);
            this.Controls.Add(radioButtonSize8);
            this.Controls.Add(radioButtonSize10);
            this.Controls.Add(labePlayers);
            this.Controls.Add(labelPlayer1);
            this.Controls.Add(labelPlayer2);
            this.Controls.Add(checkBoxPlayer2);
            this.Controls.Add(textBoxPlayer1Name);
            this.Controls.Add(textBoxPlayer2Name);
            this.Controls.Add(buttonDone);

            labelBoardSize.Text = "Board Size:";
            labelBoardSize.BackColor = Color.Aqua;
            labelBoardSize.Location = new Point(16, 16);
            labelBoardSize.AutoSize = true;

            radioButtonSize6.Text = "6x6";
            radioButtonSize6.BackColor = Color.Aqua;
            radioButtonSize6.AutoSize = true;
            radioButtonSize6.Left = labelBoardSize.Left + 16;
            radioButtonSize6.Top = labelBoardSize.Bottom + 10;

            radioButtonSize8.Text = "8x8";
            radioButtonSize8.BackColor = Color.Aqua;
            radioButtonSize8.AutoSize = true;
            radioButtonSize8.Left = radioButtonSize6.Right + 16;
            radioButtonSize8.Top = labelBoardSize.Bottom + 10;

            radioButtonSize10.Text = "10x10";
            radioButtonSize10.BackColor = Color.Aqua;
            radioButtonSize10.AutoSize = true;
            radioButtonSize10.Left = radioButtonSize8.Right + 16;
            radioButtonSize10.Top = labelBoardSize.Bottom + 10;

            labePlayers.Text = "Players:";
            labePlayers.BackColor = Color.Aqua;
            labePlayers.AutoSize = true;
            labePlayers.Left = labelBoardSize.Left;
            labePlayers.Top = radioButtonSize6.Bottom + 10;

            labelPlayer1.Text = "Player 1:";
            labelPlayer1.BackColor = Color.Aqua;
            labelPlayer1.AutoSize = true;
            labelPlayer1.Left = labePlayers.Left + 16;
            labelPlayer1.Top = labePlayers.Bottom + 10;

            checkBoxPlayer2.AutoSize = true;
            checkBoxPlayer2.Left = labelPlayer1.Left;

            labelPlayer2.Text = "Player 2:";
            labelPlayer2.BackColor = Color.Aqua;
            labelPlayer2.AutoSize = true;
            labelPlayer2.Left = checkBoxPlayer2.Right + 5;
            labelPlayer2.Top = labelPlayer1.Bottom + 10;

            checkBoxPlayer2.Top = labelPlayer2.Top + (labelPlayer2.Height - checkBoxPlayer2.Height) / 2;

            textBoxPlayer1Name.Left = labelPlayer1.Right + checkBoxPlayer2.Width + 16;
            textBoxPlayer1Name.Top = labelPlayer1.Top + (labelPlayer1.Height - textBoxPlayer1Name.Height)/2;

            textBoxPlayer2Name.Left = textBoxPlayer1Name.Left;
            textBoxPlayer2Name.Top = labelPlayer2.Top + (labelPlayer2.Height - textBoxPlayer2Name.Height) / 2;
            textBoxPlayer2Name.Enabled = false;
            textBoxPlayer2Name.Text = "[Computer]";

            buttonDone.Text = "Done";
            buttonDone.Left = textBoxPlayer2Name.Right - buttonDone.Width;
            buttonDone.Top = textBoxPlayer2Name.Bottom + 10;

            this.Text = "Game Settings";
            this.Width= buttonDone.Right;
            this.Height = buttonDone.Bottom;
            labelBoardSize.Text =buttonDone.Right.ToString();
            radioButtonSize6.Text =  this.Width.ToString();
        }

        //private RadioButton setNewSizeRadioButton(int size)
        //{
        //    RadioButton radioButton = new RadioButton();

        //    radioButton.Text = string.Format("{0}x{0}", size);

        //    return radioButton;
        //}

        
    }
}
