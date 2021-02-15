using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public interface IPlace 
    {
        void OnPlace(int _rodIndex);
    }
}