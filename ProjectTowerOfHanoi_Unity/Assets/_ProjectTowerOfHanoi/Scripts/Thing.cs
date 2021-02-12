using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Thing : MonoBehaviour
    {
        public ThingRuntimeSet MySet;

        private void OnEnable()
        {
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
            MySet.RuntimeSet.Add(this);
        }
    }
}