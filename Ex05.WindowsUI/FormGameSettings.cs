using System.Drawing;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    internal class FormGameSettings : Form
    {
        public FormGameSettings() 
        {
            Label labelBoardSize = new Label();
            const int v_Size6 = 6;
            const int v_Size8 = 8;
            const int v_Size10 = 10;
            RadioButton radioButtonSize6 =setNewSizeRadioButton(v_Size6);
            RadioButton radioButtonSize8= setNewSizeRadioButton(v_Size8);
            RadioButton radioButtonSize10= setNewSizeRadioButton(v_Size10);

            labelBoardSize.Text = "Board Size:";
            labelBoardSize.BackColor = Color.Aqua;
            labelBoardSize.Location = new Point(16, 16);
            labelBoardSize.AutoSize = true;

            radioButtonSize6.BackColor = Color.Aqua;
            radioButtonSize6.AutoSize = true;
            radioButtonSize6.PerformLayout();
            radioButtonSize6.Left = 16;
            radioButtonSize6.Top = labelBoardSize.Bottom + 10;
            

            radioButtonSize8.BackColor = Color.Aqua;
            radioButtonSize8.AutoSize = true;
            radioButtonSize8.Left = radioButtonSize6.Right;
            radioButtonSize8.Top = labelBoardSize.Bottom + 10;

            this.Controls.Add(labelBoardSize);
            this.Controls.Add(radioButtonSize6);
            this.Controls.Add(radioButtonSize8);
            this.Controls.Add(radioButtonSize10);
                        
        }

        private RadioButton setNewSizeRadioButton(int size)
        {
            RadioButton radioButton = new RadioButton();

            radioButton.Text = string.Format("{0}x{0}", size);

            return radioButton;
        }

        
    }
}
