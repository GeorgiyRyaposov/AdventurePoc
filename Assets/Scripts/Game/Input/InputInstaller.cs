using Game.Input.DevicesListeners;
using Zenject;

namespace Game.Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InputDevicesManager>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputEventsHolder>().AsSingle();
            Container.BindInterfacesAndSelfTo<KeyboardAndMouseInputListener>().AsSingle();
        }
    }
}