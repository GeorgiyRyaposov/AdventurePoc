using System.Collections.Generic;
using Common.Components;
using Common.Data;
using Game.Components.Transforms;
using UnityEngine;

namespace Game.Data
{
    [System.Serializable]
    public class GameModel
    {
        public Id CurrentLocation;
        
        public Dictionary<Id, IComponentDataDictionary> Components = new ();
        public Dictionary<Id, TransformData> Transforms = new ();
        
        public Dictionary<Id, Id> GameObjectsInstancesToTemplatesMap = new ();
        public SerializableVector3 PlayerPosition;
    }
}