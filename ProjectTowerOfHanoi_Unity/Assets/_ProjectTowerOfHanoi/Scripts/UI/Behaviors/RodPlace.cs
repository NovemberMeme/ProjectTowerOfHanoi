using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodPlace : MonoBehaviour, IPlace
    {
        public FeedbackGroup FeedbacksToStart;
        public FeedbackGroup FeedbacksToStop;

        public void OnPlace(int _rodIndex)
        {
            DelegateManager.onSelected?.Invoke(_rodIndex);
            FeedbacksToStop?.StopFeedbacks();
            FeedbacksToStart?.PlayFeedbacks();
        }
    }
}