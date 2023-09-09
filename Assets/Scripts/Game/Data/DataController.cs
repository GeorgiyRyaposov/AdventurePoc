using Common.Data;
using UnityEngine;

namespace Game.Data
{
    public class DataController : IDataController
    {
        private GameModel model;

        public void SetModel(GameModel model)
        {
            this.model = model;
        }

        public IComponentDataDictionary GetComponentsData(Id controllerId)
        {
            if (model.Components.TryGetValue(controllerId, out var data))
            {
                return data;
            }

            Debug.LogError($"<color=red>Failed to find data for {controllerId}</color>");
            return null;
        }

        public void SetComponentsData(Id controllerId, IComponentDataDictionary data)
        {
            model.Components[controllerId] = data;
        }
    }
}