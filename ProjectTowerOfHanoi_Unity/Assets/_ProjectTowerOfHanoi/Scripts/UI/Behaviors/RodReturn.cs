using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodReturn : MonoBehaviour, IReturn
    {
        public FeedbackGroup OnReturnFeedbacks;

        public void OnReturn(int _rodIndex)
        {
            DelegateManager.onSelected?.Invoke(_rodIndex);
            OnReturnFeedbacks?.PlayFeedbacks();
        }
    }
}