using EnglishCheckers;
using System;
using System.Windows.Forms;

namespace Ex05.WindowsUI
{
    public class FormEnglishCheckers : Form
    {
        private Game m_Game;
        public FormEnglishCheckers() 
        {
            Label Player1Name=new Label();
            Label Player2Name=new Label();
            Label Player1Score=new Label();
            Label Player2Score=new Label();
        }
    }
}
