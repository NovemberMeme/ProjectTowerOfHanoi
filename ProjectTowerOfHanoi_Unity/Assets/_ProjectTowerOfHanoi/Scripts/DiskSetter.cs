using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class DiskSetter : MonoBehaviour
    {
        public DataBaseSO DB;
        public GameObject DiskPrefab;

        private void Start()
        {
            SetDisks();
        }

        private void OnEnable()
        {
            DelegateManager.onSelected += DB.OnSelected;
        }

        private void OnDisable()
        {
            DelegateManager.onSelected -= DB.OnSelected;
        }

        public void SetDisks()
        {
            DB.SetPickUpPositions();

            List<Disk> newDisks = new List<Disk>();
            for (int i = 0; i < DB.DiskCount; i++)
            {
                GameObject newDiskGO = Instantiate(DiskPrefab, transform.position, Quaternion.identity);
                Disk newDisk = newDiskGO.GetComponent<Disk>();
                newDisk.MyDiskSizeIndex = i;
                float newScale = (newDisk.MyDiskSizeIndex * DB.SizeScaleFactor) + 1;
                newDiskGO.transform.localScale = new Vector3(newScale, newDiskGO.transform.localScale.y, newScale);
                newDisks.Add(newDisk);
            }

            DB.DiskSets[0].RuntimeSet.Reverse();

            for (int i = newDisks.Count - 1; i >= 0; i--)
            {
                DB.PickUp(newDisks[i], false);
                DB.Place(0, false);
            }
        }
    }
}