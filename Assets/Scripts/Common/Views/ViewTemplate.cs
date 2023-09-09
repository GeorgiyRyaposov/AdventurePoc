using UnityEngine;

namespace Common.Views
{
    [CreateAssetMenu(fileName = "View template", menuName = "ScriptableObjects/View")]
    public class ViewTemplate : ScriptableObject
    {
        [SerializeField] private GameObject prefab;

        public GameObject Prefab => prefab;
    }
}