using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public static class DelegateManager 
    {
        public delegate void OnSelected(int _rodIndex);
        public static OnSelected onSelected;
    }
}