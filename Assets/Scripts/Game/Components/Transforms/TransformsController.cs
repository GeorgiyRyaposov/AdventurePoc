using Common.Components;
using Common.Data;
using Game.Data;
using UnityEngine;
using Zenject;

namespace Game.Components.Transforms
{
    public class TransformsController : MonoBehaviour, IComponentsController
    {
        [SerializeField]
        private ScriptableId controllerId;
        
        public Id Id => controllerId.Value;

        private IDataController dataController;

        [Inject]
        private void Inject(IDataController dataController)
        {
            this.dataController = dataController;
        }

        public TransformData GetTransformData(Id gameObjectId)
        {
            return dataController.GetTransform(gameObjectId);
        }
    }
}