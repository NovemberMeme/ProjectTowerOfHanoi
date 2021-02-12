using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    [CreateAssetMenu(fileName = "New Database ScriptableObject", menuName = "New Database SO")]
    public class DataBaseSO : ScriptableObject
    {
        public Disk CurrentHeldDisk = null;

        public int DiskCount = 3;

        public Material BaseMaterial;
        public Color BaseColor;

        public float SizeScaleFactor = 1.2f;
        public float DistanceScaleFactor = 0.1f;
        public float Spacing = 1;
        public float PickUpPositionSpacing = 3;
        public float MoveSpeed = 0.25f;

        List<Vector3> pickUpPositions = new List<Vector3>();
        public List<Vector3> RodPositions = new List<Vector3>();
        public List<ThingRuntimeSet> DiskSets = new List<ThingRuntimeSet>();

        public void OnSelected(int _rodIndex)
        {
            if(CurrentHeldDisk == null)
            {
                if (DiskSets[_rodIndex].RuntimeSet.Count != 0)
                    PickUp(DiskSets[_rodIndex].GetTopMostThing().GetComponent<Disk>(), true);
            }
            else
            {
                Place(_rodIndex, true);
            }
        }

        public void PickUp(Disk _disk, bool _smooth)
        {
            // Change this to some sort of Lerp
            Thing currentDiskThing = _disk.GetComponent<Thing>();
            currentDiskThing.MySet.RuntimeSet.Remove(currentDiskThing);
            currentDiskThing.MySet = null;
            if (_smooth)
            {
                List<Vector3> destinations = new List<Vector3>();
                destinations.Add(pickUpPositions[_disk.MyRodIndex]);
                SmoothMoveData data = new SmoothMoveData(_disk, destinations);
                Utils.SmoothMove(data, MoveSpeed);
            }
            else
                _disk.transform.position = pickUpPositions[_disk.MyRodIndex];
            CurrentHeldDisk = _disk;
            //Debug.Log(CurrentHeldDisk.MyDiskSizeIndex);
        }

        public void Place(int _rodIndex, bool _smooth)
        {
            if (IsValidPlace(_rodIndex))
            {
                if (_smooth)
                {
                    List<Vector3> destinations = new List<Vector3>();
                    destinations.Add(pickUpPositions[_rodIndex]);
                    destinations.Add(GetPlacePosition(_rodIndex));
                    SmoothMoveData data = new SmoothMoveData(CurrentHeldDisk, destinations);
                    Utils.SmoothMove(data, MoveSpeed);
                }
                else
                    CurrentHeldDisk.transform.position = GetPlacePosition(_rodIndex);
                CurrentHeldDisk.GetComponent<Thing>().ChangeThing(DiskSets[_rodIndex]);
                CurrentHeldDisk.MyRodIndex = _rodIndex;
                CurrentHeldDisk.MyRodStackIndex = DiskSets[_rodIndex].RuntimeSet.Count - 1;
                CurrentHeldDisk = null;
            }
            else
            {
                Debug.Log("Invalid Placement");
            }
        }

        public Vector3 GetPlacePosition(int _rodIndex)
        {
            float yDistance = 0;

            for (int i = 0; i < DiskSets[_rodIndex].RuntimeSet.Count; i++)
            {
                yDistance += Spacing;
                yDistance += DiskSets[_rodIndex].RuntimeSet.Count * DistanceScaleFactor;
            }

            //Debug.Log(yDistance);

            return RodPositions[_rodIndex] + new Vector3(0, yDistance, 0);
        }

        public bool IsValidPlace(int _rodIndex)
        {
            if (DiskSets[_rodIndex].RuntimeSet.Count > 0)
            {
                Disk targetRodTopmostDisk = DiskSets[_rodIndex].GetTopMostThing().GetComponent<Disk>();
                return CurrentHeldDisk.MyDiskSizeIndex < targetRodTopmostDisk.MyDiskSizeIndex;
            }
            else
                return true;
        }

        public void SetPickUpPositions()
        {
            pickUpPositions.Clear();
            for (int i = 0; i < RodPositions.Count; i++)
            {
                float yDistance = 0;
                for (int j = 0; j < DiskCount; j++)
                {
                    yDistance += Spacing;
                    yDistance += DiskSets[i].RuntimeSet.Count * DistanceScaleFactor;
                }

                Vector3 newPickUpPosition = RodPositions[i] + new Vector3(0, yDistance + PickUpPositionSpacing, 0);
                Debug.Log(newPickUpPosition);
                pickUpPositions.Add(newPickUpPosition);
            }
        }
    }
}