using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace TowerOfHanoi
{
    /// <summary>
    /// Since scriptableobjects have no monobehavior callbacks, this initializes database values and subscribes
    /// database functions to needed delagates
    /// </summary>
    public class DatabaseManager : MonoBehaviour
    {
        public DataBaseSO DB;
        public UnityEvent WinEvent = new UnityEvent();

        private void Awake()
        {
            DB.CurrentSO_StateData.SetData(DB.PlacedState, 0);
            DB.GameIsOngoing = false;
        }

        private void OnEnable()
        {
            DelegateManager.onSelected += DB.OnSelected;
            DelegateManager.onDiskStateChanged += DB.OnDiskStateChanged;
            DelegateManager.win += Win;
        }

        private void OnDisable()
        {
            DelegateManager.onSelected -= DB.OnSelected;
            DelegateManager.onDiskStateChanged -= DB.OnDiskStateChanged;
            DelegateManager.win -= Win;
        }

        public void Win()
        {
            WinEvent.Invoke();
        }
    }
}