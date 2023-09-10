using System.Collections.Generic;
using Common.Data;
using Common.GameObjects;
using Game.Components.Transforms;
using UnityEngine;

namespace Game.Data.Scenes
{
    [CreateAssetMenu(fileName = "LocationScenes", menuName = "ScriptableObjects/LocationScenes")]
    public class LocationScenes : ScriptableObject
    {
        [SerializeField] private List<string> scenes;
        public List<string> Scenes => scenes;
        
        [SerializeField, HideInInspector] private LocationGameObjects locationGameObjects;
        public LocationGameObjects LocationGameObjects => locationGameObjects;
        
#if UNITY_EDITOR
        private void SetLocationGameObjects(LocationGameObjects value)
        {
            locationGameObjects = value;
        }
        
        [UnityEditor.CustomEditor(typeof(LocationScenes))]
        public class LocationScenesEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                if (GUILayout.Button("Update game objects"))
                {
                    var data = (LocationScenes)target;
                    
                    var templateHolders = FindObjectsByType<GameObjectTemplateHolder>(FindObjectsSortMode.None);
                    var result = new LocationGameObjects();
                    foreach (var templateHolder in templateHolders)
                    {
                        var objectId = Id.Create();
                        
                        var transform = templateHolder.transform;
                        result.TransformData.Add(new TransformData()
                        {
                            Id = objectId,
                            Position = transform.position,
                            Rotation = transform.rotation,
                            Scale = transform.localScale,
                        });

                        result.GameObjectInstances.Add(new GameObjectInstance()
                        {
                            InstanceId = objectId,
                            TemplateId = templateHolder.Template.Id,
                        });
                    }

                    data.SetLocationGameObjects(result);
                }

                DrawDefaultInspector();
            }
        }
#endif
    }
}