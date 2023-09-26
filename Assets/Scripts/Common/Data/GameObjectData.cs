using Common.Views;

namespace Common.Data
{
    public struct GameObjectData
    {
        public Id InstanceId;
        public Id TemplateId;

        public GameObjectData(IGameObjectView view)
        {
            InstanceId = view.InstanceId;
            TemplateId = view.TemplateId;
        }
    }
}