using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    [System.Serializable]
    public class SO_StateData
    {
        public SO_State SO_State;
        public int RodIndex;

        public SO_StateData(SO_State _newState, int _newIndex)
        {
            SO_State = _newState;
            RodIndex = _newIndex;
        }

        public void SetData(SO_State _newState, int _newIndex)
        {
            SO_State = _newState;
            RodIndex = _newIndex;
        }
    }
}