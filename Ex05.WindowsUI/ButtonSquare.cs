using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    internal class ButtonSquare : Button
    {
        public int Row { get; }
        public int Column { get; }

        public ButtonSquare(int i_Row, int i_Column)
        {
            Row = i_Row;
            Column = i_Column;
        }
    }
}