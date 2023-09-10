using System.Threading.Tasks;
using Game.Components.Transforms;
using Game.GameObjectsViews;
using Zenject;

namespace Game.Locations
{
    public class LocationStarter
    {
        private GameObjectsController gameObjectsController;
        private TransformsController transformsController;
        private LocationController locationController;
        
        [Inject]
        private void Inject(GameObjectsController gameObjectsController, TransformsController transformsController)
        {
            this.gameObjectsController = gameObjectsController;
            this.transformsController = transformsController;
        }
        
        public async Task PrepareLocation()
        {
            var gameObjects = gameObjectsController.GetGameObjects();
            var spawnedCount = 0;
            
            for (var i = 0; i < gameObjects.Count; i++)
            {
                var gameObjectId = gameObjects[i];
                var position = transformsController.GetPosition(gameObjectId);
                if (!locationController.IsPositionAtLocation(position))
                {
                    continue;
                }
                
                gameObjectsController.CreateGameObjectView(gameObjectId);
                spawnedCount++;

                if (spawnedCount % 10 == 0)
                {
                    await Task.Yield();
                }
            }
        }
    }
}