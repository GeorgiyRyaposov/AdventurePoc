using UnityEngine;

namespace Common.SceneObjects
{
    public class GameObjectTemplateHolder : MonoBehaviour
    {
        [SerializeField] private GameObjectTemplate template;
        public GameObjectTemplate Template => template;
    }
}