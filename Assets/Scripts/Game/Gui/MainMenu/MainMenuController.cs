using Zenject;

namespace Game.Gui.MainMenu
{
    public class MainMenuController : IInitializable
    {
        private readonly MainMenuPresenter mainMenuPresenter;
        private readonly MainMenuView mainMenuView;

        public MainMenuController(MainMenuPresenter mainMenuPresenter, MainMenuView mainMenuView)
        {
            this.mainMenuPresenter = mainMenuPresenter;
            this.mainMenuView = mainMenuView;
        }
        
        public void Initialize()
        {
            mainMenuPresenter.Attach(mainMenuView);
        }
    }
}