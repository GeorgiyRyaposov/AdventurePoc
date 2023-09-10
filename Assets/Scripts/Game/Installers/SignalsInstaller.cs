using Game.Signals;
using Zenject;

namespace Game.Installers
{
    public class SignalsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<LocationChanged>();
        }
    }
}