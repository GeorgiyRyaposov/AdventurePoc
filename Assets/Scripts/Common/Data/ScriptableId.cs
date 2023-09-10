using UnityEngine;

namespace Common.Data
{
    [CreateAssetMenu(fileName = "Entity name - Id", menuName = "ScriptableObjects/Id")]
    public class ScriptableId : ScriptableObject
    {
        [SerializeField, HideInInspector] private Id value;
        
        public Id Value => value;

        private void OnValidate()
        {
            if (value.IsZero)
            {
                value = Id.Create();
            }
        }
    }
}