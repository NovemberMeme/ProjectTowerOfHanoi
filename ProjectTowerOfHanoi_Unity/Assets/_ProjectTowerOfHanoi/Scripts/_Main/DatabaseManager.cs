using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class DatabaseManager : MonoBehaviour
    {
        public DataBaseSO DB;

        private void Awake()
        {
            DB.CurrentSO_StateData.SetData(DB.StateDefinition.PlacedState, 0);
        }

        private void OnEnable()
        {
            DelegateManager.onSelected += DB.OnSelected;
            DelegateManager.onDiskStateChanged += DB.OnDiskStateChanged;
        }

        private void OnDisable()
        {
            DelegateManager.onSelected -= DB.OnSelected;
            DelegateManager.onDiskStateChanged -= DB.OnDiskStateChanged;
        }
    }
}