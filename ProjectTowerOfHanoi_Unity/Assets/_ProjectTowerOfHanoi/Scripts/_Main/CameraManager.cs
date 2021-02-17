using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Since scriptableobject fields cannot have scene gameobjects assigned to them, this script assigns them for it
    /// </summary>
    public class CameraManager : MonoBehaviour
    {
        public DataBaseSO DB;

        public float GameOpeningTransitionDelay = 1;

        /// <summary>
        /// The first thing the player sees upon opening the game is empty space so that when it blends into the camera
        /// aimed at the main menu it acts as a pleasant transition
        /// </summary>
        public CinemachineVirtualCamera OffCM;
        public CinemachineVirtualCamera MainMenuCM;
        public CinemachineVirtualCamera LoadMenuCM;
        public CinemachineVirtualCamera SettingsMenuCM;
        public CinemachineVirtualCamera DiskSetupMenuCM;
        public CinemachineVirtualCamera GameCM;

        private void Awake()
        {
            InitializeCameras();
        }

        /// <summary>
        /// Assigns the specific cinemachine virtual cameras already set up in the scene,
        /// then plays the game's opening camera animation using a cinemachine virtual camera blend 
        /// after a configurable delay
        /// </summary>
        private void InitializeCameras()
        {
            DB.OffCM = OffCM;
            DB.MainMenuCM = MainMenuCM;
            DB.LoadMenuCM = LoadMenuCM;
            DB.SettingsMenuCM = SettingsMenuCM;
            DB.DiskSetupMenuCM = DiskSetupMenuCM;
            DB.GameCM = GameCM;

            StartCoroutine(_OpenGameTransitionDelay());
        }

        private IEnumerator _OpenGameTransitionDelay()
        {
            DB.TransitionCamera(DB.OffCM);
            yield return new WaitForSeconds(GameOpeningTransitionDelay);
            DB.TransitionCamera(DB.MainMenuCM);
        }
    }
}