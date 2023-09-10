using System.Collections.Generic;
using UnityEngine;

namespace Common.GameObjects
{
    [CreateAssetMenu(fileName = "GameObject template", menuName = "ScriptableObjects/GameObject")]
    public class GameObjectsTemplates : ScriptableObject
    {
        [SerializeField] private List<GameObjectTemplate> values;
        public List<GameObjectTemplate> Values => values;
    }
}