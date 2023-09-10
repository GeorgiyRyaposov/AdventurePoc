using Game.Loaders;
using UnityEngine;

namespace Game.Gui.MainMenu
{
    public class MainMenuPresenter
    {
        private MainMenuView view;
        private readonly GameStarter gameStarter;

        public MainMenuPresenter(GameStarter gameStarter)
        {
            this.gameStarter = gameStarter;
        }
        
        public void Attach(MainMenuView mainMenuView)
        {
            view = mainMenuView;
            
            view.NewGame.onClick.AddListener(NewGameClicked);
            view.LoadGame.onClick.AddListener(LoadGameClicked);
            view.Exit.onClick.AddListener(ExitClicked);
            
            view.LoadGame.interactable = gameStarter.HasSavedGame;
        }

        private void NewGameClicked()
        {
            gameStarter.StartNewGame();
        }
        
        private void LoadGameClicked()
        {
            gameStarter.LoadGame();
        }

        private void ExitClicked()
        {
            Application.Quit();
        }
    }
}