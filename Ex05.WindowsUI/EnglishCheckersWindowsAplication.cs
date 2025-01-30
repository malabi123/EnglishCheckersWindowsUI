using EnglishCheckers;
namespace Ex05.WindowsUI
{
    internal class EnglishCheckersWindowsAplication
    {
        private FormEnglishCheckers m_FormEnglishCheckers;
        private FormGameSettings m_FormGameSettings;
        private Game m_Game;

        public EnglishCheckersWindowsAplication() { }

        public void Start()
        {
            m_FormEnglishCheckers = new FormEnglishCheckers();
            m_Game = new Game();
            
            m_FormEnglishCheckers.ShowDialog();

            setGameSettings();
            
        }

        private void setGameSettings()
        {
            m_Game.SetNewPlayer();
        }
    }
}
