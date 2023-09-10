using UnityEngine;
using Zenject;

namespace Game.Gui.MainMenu
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField]
        private MainMenuView mainMenuView;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle();
            Container.Bind<MainMenuPresenter>().AsSingle();
            Container.Bind<MainMenuView>().FromInstance(mainMenuView).AsSingle();
        }
    }
}