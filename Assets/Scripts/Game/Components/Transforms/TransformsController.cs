using Common.Components;
using Common.Data;
using UnityEngine;

namespace Game.Components.Transforms
{
    public class TransformsController : MonoBehaviour, IComponentsController
    {
        [SerializeField]
        private ScriptableId controllerId;
        
        public Id Id => controllerId.Value;
        
        
    }
}