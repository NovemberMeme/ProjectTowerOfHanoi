using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Data about the current held disk's disk state as well as the rod index of the last rod interacted with.
    /// In the current case, knowing the last rod interacted with indicates whether to play the return feedbacks 
    /// meant to be played if the player puts a held disk back on the same rod they picked it up from, or to play the
    /// place feedbacks meant to be played if the player puts a held disk in any new rod
    /// </summary>
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