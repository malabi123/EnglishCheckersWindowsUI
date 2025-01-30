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
            m_FormGameSettings = new FormGameSettings();
            m_FormGameSettings.ShowDialog();

            if (m_FormGameSettings.IsDone)
            {
                m_Game = setGameAndSettings();
                m_FormEnglishCheckers = new FormEnglishCheckers(m_Game);
                m_FormEnglishCheckers.ShowDialog();
            }
        }

        private Game setGameAndSettings()
        {
            Game game = new Game();

            game.SetNewPlayer(m_FormGameSettings.Player1Name);

            if (m_FormGameSettings.IsTwoPlayers)
            {
                game.SetNewPlayer(m_FormGameSettings.Player2Name);
            }

            game.SetBoard(m_FormGameSettings.BoardSize);

            game.InitializeFirstGame();

            return game;
        }
    }
}
