using System;
using System.Collections.Generic;
using System.Linq;
using Common.Components;
using Common.Data;
using Game.Components.Transforms;
using Game.Signals;
using UnityEngine;
using Zenject;

namespace Game.Data
{
    public class DataController : IDataController, IGameModelHolder
    {
        private GameModel model;
        private SignalBus signalBus;
        
        [Inject]
        public void Construct(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }
        
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

        public void SetCurrentLocation(Id locationId)
        {
            model.CurrentLocation = locationId;
            signalBus.Fire<LocationChanged>();
        }

        public Id GetCurrentLocation()
        {
            return model.CurrentLocation;
        }

        public Dictionary<Id, Id> GetGameObjectsToTemplatesMap()
        {
            return model.GameObjectsInstancesToTemplatesMap;
        }

        public TransformData GetTransform(Id objectId)
        {
            return model.Transforms[objectId];
        }
    }
}