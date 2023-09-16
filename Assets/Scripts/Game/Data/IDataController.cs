using System.Collections.Generic;
using Common.Components;
using Common.Data;
using Game.Components.Transforms;

namespace Game.Data
{
    public interface IDataController
    {
        IComponentDataDictionary GetComponentsData(Id controllerId);
        void SetComponentsData(Id controllerId, IComponentDataDictionary data);
        void SetCurrentLocation(Id locationId);
        Id GetCurrentLocation();

        Dictionary<Id, Id> GetGameObjectsToTemplatesMap();
        TransformData GetTransform(Id objectId);
        void SetTransform(Id objectId, TransformData data);
    }
}