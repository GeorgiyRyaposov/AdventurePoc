using UnityEngine;

namespace Game.Gui.MainMenu
{
    public class MainMenuPresenter
    {
        private MainMenuView view;
        
        public void Attach(MainMenuView mainMenuView)
        {
            view = mainMenuView;
            
            view.NewGame.onClick.AddListener(NewGameClicked);
            view.LoadGame.onClick.AddListener(LoadGameClicked);
            view.Exit.onClick.AddListener(ExitClicked);
            
            view.LoadGame.interactable = ServicesMediator.GameStarter.HasSavedGame;
        }

        private void NewGameClicked()
        {
            ServicesMediator.GameStarter.StartNewGame();
        }
        
        private void LoadGameClicked()
        {
            ServicesMediator.GameStarter.LoadGame();
        }

        private void ExitClicked()
        {
            Application.Quit();
        }
    }
}