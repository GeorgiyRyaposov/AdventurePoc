using System.Collections.Generic;
using Common.Data;

namespace Game.Data
{
    [System.Serializable]
    public class GameModel
    {
        public Dictionary<Id, IComponentDataDictionary> Components = new ();
    }
}