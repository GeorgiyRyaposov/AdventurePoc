﻿using Common.ServiceLocator;
using Game.Data;
using Game.Data.Scenes;
using UnityEngine;

namespace Game.Loaders
{
    [CreateAssetMenu(fileName = "GameStarter", menuName = "Services/GameStarter")]
    public class GameStarter : ScriptableObject, IInitializableService
    {
        [SerializeField] private LocationsHolder locationsHolder;
        public bool HasSavedGame;
        
        
        public void Initialize()
        {
            //for case when there is no saved game
            //and game started not from start scene 
            var gameModelHolder = ServicesMediator.GameModelHolder;
            if (!gameModelHolder.HasModel())
            {
                gameModelHolder.SetModel(CreateNewGameModel());
            }
        }
        public void Dispose()
        {
            
        }

        public void StartNewGame()
        {
            ServicesMediator.GameModelHolder.SetModel(CreateNewGameModel());
            ServicesMediator.SceneTransitionController.Load(locationsHolder.StartingLocation.Id);
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

        public void LoadGame()
        {
            
        }
    }
}