using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TowerOfHanoi
{
    public interface IPickUp
    {
        void OnPickUp(int _index);
    }
}