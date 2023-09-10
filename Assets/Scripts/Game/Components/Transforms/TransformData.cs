using System;
using Common.Components;
using Common.Data;

namespace Game.Components.Transforms
{
    [Serializable]
    public class TransformData : IComponentData
    {
        public Id Id { get; set; }
        
        public SerializableVector3 Position;
        public SerializableQuaternion Rotation;
        public SerializableVector3 Scale;
    }
}