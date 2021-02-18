using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

namespace TowerOfHanoi
{
    /// <summary>
    /// Handles exposed functions for menu buttons other than settings menu UI.
    /// Also handles disk count choices of the player
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [Header("Disk Setup Menu: ")]

        public DataBaseSO DB;
        public TextMeshProUGUI DiskCountText;

        public Slider DiskCountSlider;

        public UnityEvent SetDisksEvent = new UnityEvent();

        /// <summary>
        /// Uses a slider to dynamically adjust the disk count
        /// </summary>
        /// <param name="_diskCount"></param>
        public void SetDiskCount(float _diskCount)
        {
            DB.DiskCount = Mathf.RoundToInt(_diskCount);
            DiskCountText.text = DB.DiskCount.ToString();
            DelegateManager.setupDisks(DB.DiskCount);
            SetDisksEvent.Invoke();
        }

        public void BeginGame()
        {
            DB.GameIsOngoing = true;
        }

        public void EndGame()
        {
            DB.GameIsOngoing = false;
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}