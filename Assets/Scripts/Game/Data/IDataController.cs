using Common.Data;

namespace Game.Data
{
    public interface IDataController
    {
        IComponentDataDictionary GetComponentsData(Id controllerId);
        void SetComponentsData(Id controllerId, IComponentDataDictionary data);
    }
}