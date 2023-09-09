using Game.Components.Transforms;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class ComponentsInstaller : MonoInstaller
    {
        [SerializeField] private TransformsController transformsController;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TransformsController>().FromComponentInNewPrefab(transformsController).AsSingle();
        }
    }
}