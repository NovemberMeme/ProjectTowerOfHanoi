using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public interface ISelect
    {
        void OnSelect(int _index);
    }
}