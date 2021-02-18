using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
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