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
        private PreloaderController preloader;
        
        [SerializeField]
        private LocationsHolder locationsHolder;
        
        [SerializeField]
        private GameObjectsTemplates templates;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<DataController>().AsSingle();
            Container.BindInterfacesTo<GameObjectsPool>().AsSingle();
            
            Container.BindInterfacesTo<GameObjectsController>().AsSingle();
            
            Container.BindInterfacesTo<GameStarter>().AsSingle();
            Container.BindInterfacesTo<SceneTransitionController>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<SceneUnloader>().AsSingle();
            Container.BindInterfacesTo<LocationController>().AsSingle();
            Container.BindInterfacesTo<LocationStarter>().AsSingle();
            
            Container.BindInterfacesTo<PreloaderController>().FromComponentInNewPrefab(preloader).AsSingle();
            
            Container.Bind<LocationsHolder>().FromInstance(locationsHolder).AsSingle();
            Container.Bind<GameObjectsTemplates>().FromInstance(templates).AsSingle();
        }
    }
}