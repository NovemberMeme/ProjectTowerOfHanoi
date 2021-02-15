using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class MaterialManager : MonoBehaviour
    {
        public Color ColorToSet;
        public Material MaterialToUpdate;

        [ContextMenu("Set Color")]
        public void SetColor()
        {
            
        }
    }
}