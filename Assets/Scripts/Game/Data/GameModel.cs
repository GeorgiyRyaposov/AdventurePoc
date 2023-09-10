using System.Collections.Generic;
using Common.Components;
using Common.Data;

namespace Game.Data
{
    [System.Serializable]
    public class GameModel
    {
        public Dictionary<Id, IComponentDataDictionary> Components = new ();
    }
}