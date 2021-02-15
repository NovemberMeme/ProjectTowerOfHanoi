using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Disk : MonoBehaviour
    {
        public int MyRodIndex;
        public int MyRodStackIndex;
        public int MyDiskSizeIndex;

        public DataBaseSO DB;

        public Disk(int _diskSizeIndex)
        {
            MyDiskSizeIndex = _diskSizeIndex;
        }
    }
}