using System;
using Common.Components;
using Common.Data;

namespace Game.Components.Transforms
{
    [Serializable]
    public struct TransformData : IComponentData
    {
        public Id Id { get => id; set => id = value; }

        private Id id;
        
        public SerializableVector3 Position;
        public SerializableQuaternion Rotation;
        public SerializableVector3 Scale;
    }
}