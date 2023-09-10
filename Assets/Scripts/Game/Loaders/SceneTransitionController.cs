using Common.Data;
using Game.Data;
using Game.Locations;
using Zenject;

namespace Game.Loaders
{
    public class SceneTransitionController
    {
        private IDataController dataController;
        private SceneLoader sceneLoader;
        private SceneUnloader sceneUnloader;
        private LocationStarter locationStarter;
        private PreloaderController preloaderController;
        
        [Inject]
        private void Inject(IDataController dataController, SceneLoader sceneLoader,
            PreloaderController preloaderController, SceneUnloader sceneUnloader,
            LocationStarter locationStarter)
        {
            this.dataController = dataController;
            this.sceneLoader = sceneLoader;
            this.sceneUnloader = sceneUnloader;
            this.preloaderController = preloaderController;
            this.locationStarter = locationStarter;
        }
        
        public async void Load(Id locationId)
        {
            dataController.SetCurrentLocation(locationId);

            await preloaderController.Show();

            await sceneUnloader.Unload();
            
            await sceneLoader.Load(locationId);

            await locationStarter.PrepareLocation();
            
            await preloaderController.Hide();
        }
    }
}