using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Handles most of the Tower of Hanoi gameplay rules and interactions.
    /// Also stores most of the data and developer settings for various configurable fields.
    /// </summary>
    [CreateAssetMenu(fileName = "New Database ScriptableObject", menuName = "New Database SO")]
    public class DataBaseSO : ScriptableObject
    {
        #region Fields and Properties

        public Disk CurrentHeldDisk = null;

        public int DiskCount = 3;

        public Material BaseMaterial;
        public Color BaseColor;

        /// <summary>
        /// Every succeeding disk is dynamically larger by this scale factor
        /// </summary>
        public float SizeScaleFactor = 1.2f;
        /// <summary>
        /// In case a very slight scaling distance between stacked disks is wanted, this is the float used in that calculation
        /// </summary>
        public float DistanceScaleFactor = 0.01f;
        public float Spacing = 1;
        public float PickUpPositionSpacing = 3;
        public float MoveSpeed = 0.25f;

        /// <summary>
        /// The pause between hover sound feedbacks to prevent unpleasant rapid repetitions
        /// </summary>
        public float HoverSFXCooldown = 0.2f;
        public bool IsOnHoverCooldown = false;

        /// <summary>
        /// A set of defined states, in this case disk states of the currently held disk in a Tower of Hanoi game
        /// </summary>
        public SO_StateDefinition StateDefinition;
        public SO_StateData CurrentSO_StateData;

        /// <summary>
        /// Most feedbacks are components attached to various scene gameobjects, but if any feedbacks need to be global
        /// they can be assigned to this list
        /// </summary>
        public List<FeedbackGroup> GameFeedbacks;

        List<Vector3> pickUpPositions = new List<Vector3>();
        public List<Vector3> RodPositions = new List<Vector3>();
        public List<ThingRuntimeSet> DiskSets = new List<ThingRuntimeSet>();

        [HideInInspector]
        public CinemachineVirtualCamera OffCM;
        [HideInInspector]
        public CinemachineVirtualCamera MainMenuCM;
        [HideInInspector]
        public CinemachineVirtualCamera LoadMenuCM;
        [HideInInspector]
        public CinemachineVirtualCamera SettingsMenuCM;
        [HideInInspector]
        public CinemachineVirtualCamera DiskSetupMenuCM;
        [HideInInspector]
        public CinemachineVirtualCamera GameCM;

        #endregion

        #region Tower of Hanoi Section

        /// <summary>
        /// This function is subscribed to DelegateManager.onSelected and listens for specific equivalents of 
        /// Unity's OnClick events broadcasted by RodPickup, RodPlace, and RodReturn behaviors, 
        /// and either pickups up the topmost disk of the rod that broadcasted the OnSelected event if there is
        /// currently no held disk on the database, or places the database's currently held disk on the broadcasting rod
        /// </summary>
        /// <param name="_rodIndex"></param>
        public void OnSelected(int _rodIndex)
        {
            if(CurrentHeldDisk == null)
            {
                if (DiskSets[_rodIndex].RuntimeSet.Count != 0)
                    PickUp(DiskSets[_rodIndex].GetTopMostThing().GetComponent<Disk>(), _rodIndex, true);
            }
            else
            {
                Place(_rodIndex, true);
            }
        }

        /// <summary>
        /// Picks up a disk from a rod's stack
        /// </summary>
        /// <param name="_disk"></param>
        /// <param name="_rodIndex"></param>
        /// <param name="_smooth"></param>
        public void PickUp(Disk _disk, int _rodIndex, bool _smooth)
        {
            Thing currentDiskThing = _disk.GetComponent<Thing>();
            currentDiskThing.MySet.RuntimeSet.Remove(currentDiskThing);
            currentDiskThing.MySet = null;
            if (_smooth)
            {
                CurrentSO_StateData.SetData(StateDefinition.AnimatingState, _rodIndex);
                List<Vector3> destinations = new List<Vector3>();
                destinations.Add(pickUpPositions[_disk.MyRodIndex]);
                SmoothMoveData data = new SmoothMoveData(_disk, destinations);
                Utils.SmoothMove(data, MoveSpeed, new SO_StateData(StateDefinition.HeldState, _rodIndex));
            }
            else
            {
                CurrentSO_StateData.SetData(StateDefinition.HeldState, _rodIndex);
                _disk.transform.position = pickUpPositions[_disk.MyRodIndex];
            }
            CurrentHeldDisk = _disk;
            //Debug.Log(CurrentHeldDisk.MyDiskSizeIndex);
        }

        /// <summary>
        /// Places a disk on top of a rod's stack, calculates and checks for validity using helper functions below
        /// </summary>
        /// <param name="_rodIndex"></param>
        /// <param name="_smooth"></param>
        public void Place(int _rodIndex, bool _smooth)
        {
            if (IsValidPlace(_rodIndex))
            {
                if (_smooth)
                {
                    CurrentSO_StateData.SetData(StateDefinition.AnimatingState, _rodIndex);
                    List<Vector3> destinations = new List<Vector3>();
                    destinations.Add(pickUpPositions[_rodIndex]);
                    destinations.Add(GetPlacePosition(_rodIndex));
                    SmoothMoveData data = new SmoothMoveData(CurrentHeldDisk, destinations);
                    Utils.SmoothMove(data, MoveSpeed, new SO_StateData(StateDefinition.PlacedState, _rodIndex));
                }
                else
                {
                    CurrentSO_StateData.SetData(StateDefinition.PlacedState, _rodIndex);
                    CurrentHeldDisk.transform.position = GetPlacePosition(_rodIndex);
                }
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

        /// <summary>
        /// Calculates the position of a newly stacked disk
        /// </summary>
        /// <param name="_rodIndex"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Enforces the rule of Tower of Hanoi that no disk may stack on top of a smaller disk
        /// </summary>
        /// <param name="_rodIndex"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Calculates and initializes the positions where disks would go when picked up.
        /// </summary>
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
                pickUpPositions.Add(newPickUpPosition);
            }
        }

        /// <summary>
        /// Used when the database needs to be updated by coroutines that would change the disk state only at their completion
        /// </summary>
        /// <param name="_newDiskStateData"></param>
        public void OnDiskStateChanged(SO_StateData _newDiskStateData)
        {
            CurrentSO_StateData = _newDiskStateData;
        }

        #endregion

        #region Camera Helper Functions

        /// <summary>
        /// Can be used by scripts to blend into a target cinemachine virtual camera by first resetting the priorities
        /// on all the existing virtual cameras then setting the target camera's priority one level higher
        /// </summary>
        /// <param name="_targetCamera"></param>
        public void TransitionCamera(CinemachineVirtualCamera _targetCamera)
        {
            ResetPriorities();
            _targetCamera.Priority = MainMenuCM.Priority + 1;
        }

        /// <summary>
        /// Can be used by UnityEvents to reset virtual camera priorities without using code, usually in tandem with
        /// directly setting a virtual camera's priority to 11 with the same UnityEvent system rather than thru this code
        /// </summary>
        public void ResetPriorities()
        {
            MainMenuCM.Priority = 10;
            LoadMenuCM.Priority = 10;
            SettingsMenuCM.Priority = 10;
            DiskSetupMenuCM.Priority = 10;
            GameCM.Priority = 10;
        }

        #endregion
    }
}