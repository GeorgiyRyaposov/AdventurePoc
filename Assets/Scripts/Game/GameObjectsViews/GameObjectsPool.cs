using System.Collections.Generic;
using Common.Data;
using Common.GameObjects;
using UnityEngine;
using Zenject;

namespace Game.GameObjectsViews
{
    public class GameObjectsPool : IInitializable
    {
        private GameObjectsTemplates templates;

        private readonly Dictionary<Id, GameObjectTemplate> templatesMap = new();
        private readonly Dictionary<Id, Stack<GameObjectView>> pool = new();
        private readonly HashSet<GameObjectView> used = new();

        public void Initialize()
        {
            for (var i = 0; i < templates.Values.Count; i++)
            {
                var template = templates.Values[i];
                templatesMap[template.Id] = template;
            }
        }

        public GameObjectView Get(Id templateId)
        {
            var gameObjectView = GetOrCreateGameObjectView(templateId);
            if (gameObjectView == null)
            {
                return null;
            }
            
            gameObjectView.TemplateId = templateId;
            used.Add(gameObjectView);
            return gameObjectView;
        }

        private GameObjectView GetOrCreateGameObjectView(Id templateId)
        {
            if (!pool.TryGetValue(templateId, out var stack))
            {
                stack = new Stack<GameObjectView>();
                pool[templateId] = stack;
            }

            if (stack.Count > 0)
            {
                var gameObjectView = stack.Pop();
                gameObjectView.gameObject.SetActive(true);
                return gameObjectView;
            }

            if (templatesMap.TryGetValue(templateId, out var template))
            {
                var prefab = template.ViewsTemplates[0].Prefab;
                var gameObjectView = GameObject.Instantiate(prefab);
                return gameObjectView;
            }

            Debug.LogError($"<color=red>Failed to find view {templateId}</color>");
            return null;
        }

        public void Release(GameObjectView gameObjectView)
        {
            gameObjectView.gameObject.SetActive(false);
            
            var templateId = gameObjectView.TemplateId;
            
            if (!pool.TryGetValue(templateId, out var stack))
            {
                stack = new Stack<GameObjectView>();
                pool[templateId] = stack;
            }

            used.Remove(gameObjectView);
            stack.Push(gameObjectView);
        }

        public void ClearAll()
        {
            foreach (var gameObjectView in used)
            {
                GameObject.Destroy(gameObjectView.gameObject);
            }
            used.Clear();

            foreach (var stacks in pool.Values)
            {
                while (stacks.Count > 0)
                {
                    var gameObjectView = stacks.Pop();
                    GameObject.Destroy(gameObjectView.gameObject);
                }
            }
        }
    }
}