using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

namespace TowerOfHanoi
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Disk Setup Menu: ")]

        public DataBaseSO DB;
        public TextMeshProUGUI DiskCountText;

        public Slider DiskCountSlider;

        public UnityEvent SetDisksEvent = new UnityEvent();

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