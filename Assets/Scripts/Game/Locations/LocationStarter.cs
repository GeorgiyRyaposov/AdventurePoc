using System.Threading.Tasks;
using Game.Components.Transforms;
using Game.GameObjectsViews;
using UnityEngine;
using Zenject;

namespace Game.Locations
{
    public class LocationStarter
    {
        private GameObjectsController gameObjectsController;
        private TransformsController transformsController;
        private LocationController locationController;
        
        [Inject]
        private void Inject(GameObjectsController gameObjectsController, TransformsController transformsController,
            LocationController locationController)
        {
            this.gameObjectsController = gameObjectsController;
            this.transformsController = transformsController;
            this.locationController = locationController;
        }
        
        public async Task PrepareLocation()
        {
            var gameObjects = gameObjectsController.GetGameObjects();
            var spawnedCount = 0;
            
            for (var i = 0; i < gameObjects.Count; i++)
            {
                var gameObjectId = gameObjects[i];
                var transformData = transformsController.GetTransformData(gameObjectId);
                if (!locationController.IsPositionAtLocation(transformData.Position))
                {
                    continue;
                }
                
                var view = gameObjectsController.CreateGameObjectView(gameObjectId);
                var transform = view.transform;
                
                transform.SetPositionAndRotation(transformData.Position, transformData.Rotation);
                transform.localScale = transformData.Scale;
                spawnedCount++;

                if (spawnedCount % 10 == 0)
                {
                    await Task.Yield();
                }
            }

            Debug.Log($"<color=green>Spawned items: {spawnedCount}</color>");
        }
    }
}