using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    [CreateAssetMenu(fileName = "New SO_State Definition", menuName = "SO/New SO_State Definition")]
    public class SO_StateDefinition : ScriptableObject
    {
        public SO_State AnimatingState;
        public SO_State HeldState;
        public SO_State PlacedState;
    }
}