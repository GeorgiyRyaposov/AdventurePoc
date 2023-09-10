using System.Collections.Generic;
using System.Linq;
using Common.Data;
using Game.Data;
using Game.Loaders;
using UnityEngine;
using Zenject;

namespace Game.GameObjectsViews
{
    public class GameObjectsController : ICleanUpOnLocationUnload
    {
        private GameObjectsPool gameObjectsPool;
        private IDataController dataController;
        
        private Dictionary<Id, GameObjectView> spawnedViews = new();
        
        [Inject]
        private void Construct(IDataController dataController, GameObjectsPool gameObjectsPool)
        {
            this.dataController = dataController;
            this.gameObjectsPool = gameObjectsPool;
        }
        
        public GameObjectView CreateGameObjectView(Id instanceId)
        {
            var templateId = GetTemplateId(instanceId);
            var view = gameObjectsPool.Get(templateId);

            spawnedViews[instanceId] = view;
            
            return view;
        }

        public List<Id> GetGameObjects()
        {
            return dataController.GetGameObjectsToTemplatesMap().Keys.ToList();
        }

        private Id GetTemplateId(Id instanceId)
        {
            var map = dataController.GetGameObjectsToTemplatesMap();
            if (map.TryGetValue(instanceId, out var templateId))
            {
                return templateId;
            }

            Debug.LogError($"<color=red>Failed to get template id {instanceId}</color>");
            
            return null;
        }

        public void CleanUp()
        {
            spawnedViews.Clear();
        }
    }
}