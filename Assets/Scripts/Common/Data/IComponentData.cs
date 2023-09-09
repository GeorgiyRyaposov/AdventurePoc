using System.Collections.Generic;

namespace Common.Data
{
    public interface IComponentData
    {
        Id Id { get; }
    }

    public interface IComponentDataDictionary
    {
        public Dictionary<Id, IComponentData> Data { get; }
    }
}