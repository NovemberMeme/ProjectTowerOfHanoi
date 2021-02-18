using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Usually for particle FX that have more children particle FX
    /// </summary>
    public class ChildController : MonoBehaviour
    {
        public void SetChildrenActive(bool _turnOn)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                transform.GetChild(i).gameObject.SetActive(_turnOn);
            }
        }
    }
}