using Game.Data;
using Zenject;

namespace Game.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DataController>().AsSingle();
        }
    }
}