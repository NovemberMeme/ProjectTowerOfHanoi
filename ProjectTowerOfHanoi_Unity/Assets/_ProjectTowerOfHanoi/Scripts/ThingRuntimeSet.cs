using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    [CreateAssetMenu(fileName = "New Runtime Set", menuName = "New Runtime Set")]
    public class ThingRuntimeSet : ScriptableObject
    {
        public List<Thing> RuntimeSet = new List<Thing>();

        public Thing GetTopMostThing()
        {
            if (RuntimeSet.Count == 0)
                return null;
            else if (RuntimeSet.Count == 1)
                return RuntimeSet[0];
            else
                return RuntimeSet[RuntimeSet.Count - 1];
        }
    }
}