using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TowerOfHanoi
{
    /// <summary>
    /// Mostly handles initialization of disks rather than runtime functions which are instead placed on 
    /// the database scriptableobject so that its data is globally accessible and saved
    /// </summary>
    public class DiskManager : MonoBehaviour
    {
        public DataBaseSO DB;
        public GameObject DiskPrefab;

        public List<Transform> rodTransforms;
        public List<Transform> pickUpTransforms;

        private List<Disk> allDisks = new List<Disk>();

        private void Awake()
        {
            DB.RodPositions = rodTransforms;
            DB.pickUpPositions = pickUpTransforms;
        }

        private void Start()
        {
            SetUpDisks(2);
        }

        private void OnEnable()
        {
            DelegateManager.setupDisks += SetUpDisks;
            DelegateManager.win += Win;
        }

        private void OnDisable()
        {
            DelegateManager.setupDisks -= SetUpDisks;
            DelegateManager.win -= Win;
        }

        /// <summary>
        /// Initializes the starting stack of disks based on the player's selected disk count from 2 to 12.
        /// The system can handle more than 12 but the game becaomes unpleasant to navigate
        /// </summary>
        public void SetUpDisks(int _diskCount)
        {
            ClearDisks();

            DB.SetPickUpPositions();

            for (int i = 0; i < _diskCount; i++)
            {
                // Instantiate and initialize disk fields

                GameObject newDiskGO = Instantiate(DiskPrefab, transform.position, Quaternion.identity);
                Disk newDisk = newDiskGO.GetComponent<Disk>();
                newDisk.MyDiskSizeIndex = i;
                allDisks.Add(newDisk);

                // Calculate size

                float newScale = (newDisk.MyDiskSizeIndex * DB.SizeScaleFactor) + 1;
                newDiskGO.transform.localScale = new Vector3(newScale, newDiskGO.transform.localScale.y, newScale);

                // Calculate color

                MeshRenderer newDiskRenderer = newDiskGO.GetComponent<MeshRenderer>();
                float colorScaleFactor = 1 - ((float)newDisk.MyDiskSizeIndex / (float)_diskCount);
                Color newColor = new Color(DB.BaseColor.r * colorScaleFactor, DB.BaseColor.g * colorScaleFactor, DB.BaseColor.b * colorScaleFactor);
                newDiskRenderer.material = Utils.SetNewMaterial(newColor, DB.BaseMaterial);
            }

            //DB.DiskSets[0].RuntimeSet.Reverse();

            ArrangeDisks(allDisks);
        }

        /// <summary>
        /// This function arranges the inputted list from smallest size index to largest, then adds them to the first rod's disk set
        /// which is a ThingRunTimeSet so that the largest size index goes first to the bottom, working its way to the smallest at the top
        /// </summary>
        /// <param name="_disksToSet"></param>
        public void ArrangeDisks(List<Disk> _disksToSet)
        {
            _disksToSet = _disksToSet.OrderBy(Disk => Disk.MyDiskSizeIndex).ToList();

            for (int i = _disksToSet.Count - 1; i >= 0; i--)
            {
                DB.PickUp(_disksToSet[i], 2, false);
                DB.Place(0, false);
                Thing newDiskThing = _disksToSet[i].GetComponent<Thing>();
                newDiskThing.ChangeThing(DB.DiskSets[0]);
            }
        }

        public void ClearDisks()
        {
            for (int i = 0; i < DB.DiskSets.Count; i++)
            {
                DB.DiskSets[i].RuntimeSet.Clear();
            }

            for (int i = allDisks.Count - 1; i >= 0; i--)
            {
                Destroy(allDisks[i].gameObject);
            }

            allDisks.Clear();
        }

        public void Win()
        {
            StartCoroutine(_WinClearDisksDelay());
        }

        private IEnumerator _WinClearDisksDelay()
        {
            yield return new WaitForSeconds(DB.WinClearDisksDelay);
            ClearDisks();
        }
    }
}