using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class DiskManager : MonoBehaviour
    {
        public DataBaseSO DB;
        public GameObject DiskPrefab;

        private void Start()
        {
            SetDisks();
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
                MeshRenderer newDiskRenderer = newDiskGO.GetComponent<MeshRenderer>();
                float colorScaleFactor = 1 - ((float)newDisk.MyDiskSizeIndex / (float)DB.DiskCount);
                Color newColor = new Color(DB.BaseColor.r * colorScaleFactor, DB.BaseColor.g * colorScaleFactor, DB.BaseColor.b * colorScaleFactor);
                newDiskRenderer.material = Utils.SetNewMaterial(newColor, DB.BaseMaterial);
            }

            DB.DiskSets[0].RuntimeSet.Reverse();

            for (int i = newDisks.Count - 1; i >= 0; i--)
            {
                DB.PickUp(newDisks[i], 2, false);
                DB.Place(0, false);
            }
        }
    }
}