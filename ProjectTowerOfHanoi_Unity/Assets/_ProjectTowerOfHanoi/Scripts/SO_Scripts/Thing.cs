using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// All Thing objects dynamically add themselves or remove themselves from their assigned ThingRunTimeSet whenever
    /// they are enabled/disabled respectively. The runtime list's script does not have to keep track of these if 
    /// these are the ones adding or removing themselves from the list.
    /// Any gameobject can be classified as multiple Things and therefore it would add/remove itself from multiple lists
    /// </summary>
    public class Thing : MonoBehaviour
    {
        public ThingRuntimeSet MySet;

        private void OnEnable()
        {
            if(MySet != null)
                MySet.RuntimeSet.Add(this);
        }

        private void OnDisable()
        {
            if(MySet != null)
                MySet.RuntimeSet.Remove(this);
        }

        public void ChangeThing(ThingRuntimeSet _newSet)
        {
            if(MySet != null)
                MySet.RuntimeSet.Remove(this);

            MySet = _newSet;

            if(_newSet != null)
                MySet.RuntimeSet.Add(this);
        }
    }
}