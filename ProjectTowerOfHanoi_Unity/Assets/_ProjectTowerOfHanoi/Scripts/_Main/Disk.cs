using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// A Tower of Hanoi disk 
    /// </summary>
    public class Disk : MonoBehaviour
    {
        /// <summary>
        /// Defines which rod this disk currently belongs to
        /// </summary>
        public int MyRodIndex;
        /// <summary>
        /// Defines what position this disk takes on its rod's disk stack
        /// </summary>
        public int MyRodStackIndex;
        /// <summary>
        /// All disks have a unique, dynamically-calculated size which is saved in this field
        /// </summary>
        public int MyDiskSizeIndex;

        public DataBaseSO DB;

        public Disk(int _diskSizeIndex)
        {
            MyDiskSizeIndex = _diskSizeIndex;
        }
    }
}