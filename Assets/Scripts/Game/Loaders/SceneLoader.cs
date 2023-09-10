using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Data;
using Game.Data.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Loaders
{
    public class SceneLoader
    {
        private LocationsHolder locationsHolder;
        private List<ILocationLoadedListener> locationLoadedListeners;

        [Inject]
        private void Inject(LocationsHolder locationsHolder, List<ILocationLoadedListener> locationLoadedListeners)
        {
            this.locationsHolder = locationsHolder;
            this.locationLoadedListeners = locationLoadedListeners;
        }

        public async Task Load(Id locationId)
        {
            var scenesData = locationsHolder.Values.Find(x => x.Id == locationId);
            if (scenesData == null)
            {
                Debug.LogError($"<color=red>Failed to find scene {locationId}</color>");
                return;
            }

            var asyncOperations = new List<AsyncOperation>(scenesData.Scenes.Count);
            for (var i = 0; i < scenesData.Scenes.Count; i++)
            {
                var sceneData = scenesData.Scenes[i];
                
                var op = SceneManager.LoadSceneAsync(sceneData, LoadSceneMode.Additive);
                op.allowSceneActivation = true;
                asyncOperations.Add(op);
            }
            
            while (!IsAllOperationsDone(asyncOperations))
            {
                await Task.Yield();
            }

            foreach (var locationLoadedListener in locationLoadedListeners)
            {
                locationLoadedListener.OnLocationLoaded();
            }
        }

        private bool IsAllOperationsDone(List<AsyncOperation> asyncOperations)
        {
            for (var i = 0; i < asyncOperations.Count; i++)
            {
                if (!asyncOperations[i].isDone)
                {
                    return false;
                }
            }

            return true;
        }
    }
}