using System.Collections.Generic;
using Common.Components;
using Common.Data;
using Common.Views;
using UnityEngine;

namespace Common.SceneObjects
{
    [CreateAssetMenu(fileName = "GameObject template", menuName = "ScriptableObjects/GameObject")]
    public class GameObjectTemplate : ScriptableObject
    {
        [SerializeField] private Id id;
        public Id Id => id;
        
        [SerializeField] private List<ViewTemplate> viewsTemplates;
        public List<ViewTemplate> ViewsTemplates => viewsTemplates;
        
        [SerializeField] private List<ComponentTemplate> componentsTemplates;
        public List<ComponentTemplate> ComponentsTemplates => componentsTemplates;
        
        private void OnValidate()
        {
            if (id.IsZero)
            {
                id = Id.Create();
            }
        }
    }
}