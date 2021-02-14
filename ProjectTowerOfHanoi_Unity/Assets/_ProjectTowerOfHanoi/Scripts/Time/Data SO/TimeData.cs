using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WereAllGonnaDieAnywayNew
{
    [CreateAssetMenu(fileName = "New Time Data", menuName = "New Time Data")]
    public class TimeData : ScriptableObject
    {
        public float CurrentTime;

        public bool ShouldLoad = false;
    }
}