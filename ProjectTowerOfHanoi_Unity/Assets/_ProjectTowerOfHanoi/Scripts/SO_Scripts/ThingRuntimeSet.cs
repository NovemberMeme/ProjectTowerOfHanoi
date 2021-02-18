using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Keeps track of a list of a defined set of Things at runtime.
    /// In this case it is mostly used to track the disk stacks of each rod
    /// </summary>
    [CreateAssetMenu(fileName = "New Runtime Set", menuName = "New Runtime Set")]
    public class ThingRuntimeSet : ScriptableObject
    {
        public List<Thing> RuntimeSet = new List<Thing>();

        /// <summary>
        /// Helper function to simplify getting the topmost thing when accessed from other scripts
        /// </summary>
        /// <returns></returns>
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