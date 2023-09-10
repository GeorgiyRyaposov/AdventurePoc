using Common.GameObjects;
using Game.Data;
using Game.Data.Scenes;
using Game.GameObjectsViews;
using Game.Loaders;
using Game.Locations;
using UnityEngine;
using Zenject;

namespace Game.Installers
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField]
        private LocationsHolder locationsHolder;
        
        [SerializeField]
        private GameObjectsTemplates templates;
        
        [SerializeField]
        private TechnicalData technicalData;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<DataController>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameObjectsPool>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameObjectsController>().AsSingle();
            
            Container.Bind<GameStarter>().AsSingle();
            Container.Bind<SceneTransitionController>().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<SceneUnloader>().AsSingle();
            Container.BindInterfacesAndSelfTo<LocationController>().AsSingle();
            Container.Bind<LocationStarter>().AsSingle();
            Container.Bind<PreloaderController>().AsSingle();
            
            Container.Bind<LocationsHolder>().FromInstance(locationsHolder).AsSingle();
            Container.Bind<GameObjectsTemplates>().FromInstance(templates).AsSingle();
            Container.Bind<TechnicalData>().FromInstance(technicalData).AsSingle();
        }
    }
}