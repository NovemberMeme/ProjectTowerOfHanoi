using UnityEngine;

namespace TowerOfHanoi
{
    public class RodPickUp : MonoBehaviour, IPickUp
    {
        public FeedbackGroup FeedbacksToStart;
        public FeedbackGroup FeedbacksToStop;

        public void OnPickUp(int _rodIndex)
        {
            DelegateManager.onSelected?.Invoke(_rodIndex);
            FeedbacksToStop?.StopFeedbacks();
            FeedbacksToStart?.PlayFeedbacks();
        }
    }
}