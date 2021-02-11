using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    [CreateAssetMenu(fileName = "New Database ScriptableObject", menuName = "New Database SO")]
    public class DataBaseSO : ScriptableObject
    {
        public Vector3 RodPos1;
        public Vector3 RodPos2;
        public Vector3 RodPos3;

        public int DiskCount = 3;
        public List<Disk> AllDisks = new List<Disk>();

        public float SizeScaleFactor = 1.2f;
        public float DistanceScaleFactor = 0.1f;
        public float Spacing = 1;

        public void PickUp(Disk _disk)
        {

        }

        public void Place(Disk _disk)
        {

        }

        private void GetPickUpDistance()
        {
            for (int i = 0; i < DiskCount; i++)
            {

            }
        }
    }
}