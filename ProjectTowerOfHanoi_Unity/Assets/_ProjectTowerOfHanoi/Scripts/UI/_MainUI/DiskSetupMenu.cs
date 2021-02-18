using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace TowerOfHanoi
{
    /// <summary>
    /// Manages the UI of the Disk Setup Menu
    /// </summary>
    public class DiskSetupMenu : MonoBehaviour
    {
        public DataBaseSO DB;
        public TextMeshProUGUI DiskCountText;

        public Slider DiskCountSlider;

        public void SetDiskCount(float _diskCount)
        {
            DB.DiskCount = Mathf.RoundToInt(_diskCount);
            DiskCountText.text = DB.DiskCount.ToString();
            DelegateManager.setupDisks(DB.DiskCount);
        }
    }
}