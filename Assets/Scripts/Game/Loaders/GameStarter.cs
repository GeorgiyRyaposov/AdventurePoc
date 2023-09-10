using Game.Data;
using Game.Data.Scenes;
using UnityEngine;
using Zenject;

namespace Game.Loaders
{
    public class GameStarter : MonoBehaviour
    {
        private LocationsHolder locationsHolder;
        private IGameModelHolder gameModelHolder;
        private SceneTransitionController sceneTransitionController;

        [Inject]
        private void Inject(IGameModelHolder gameModelHolder,
            SceneTransitionController sceneTransitionController,
            LocationsHolder locationsHolder)
        {
            this.gameModelHolder = gameModelHolder;
            this.locationsHolder = locationsHolder;
            this.sceneTransitionController = sceneTransitionController;
        }
        
        public void StartNewGame()
        {
            var model = CreateNewGameModel();
            
            gameModelHolder.SetModel(model);
            
            sceneTransitionController.Load(locationsHolder.StartingLocation.Id);
        }

        private GameModel CreateNewGameModel()
        {
            var gameModel = new GameModel();
            
            for (var i = 0; i < locationsHolder.Values.Count; i++)
            {
                var location = locationsHolder.Values[i];
                var gameObjects = location.LocationGameObjects;
                for (var j = 0; j < gameObjects.TransformData.Count; j++)
                {
                    var transformData = gameObjects.TransformData[j];
                    gameModel.Transforms[transformData.Id] = transformData;
                }

                for (var j = 0; j < gameObjects.GameObjectInstances.Count; j++)
                {
                    var gameObjectInstance = gameObjects.GameObjectInstances[j];
                    gameModel.GameObjectsInstancesToTemplatesMap[gameObjectInstance.InstanceId] =
                        gameObjectInstance.TemplateId;
                }
            }

            return gameModel;
        }
    }
}