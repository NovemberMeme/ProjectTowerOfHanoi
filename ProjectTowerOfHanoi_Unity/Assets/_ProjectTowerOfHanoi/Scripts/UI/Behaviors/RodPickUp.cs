using UnityEngine;

namespace TowerOfHanoi
{
    public class RodPickUp : MonoBehaviour, IPickUp
    {
        public FeedbackGroup onSelectFeedbacks;

        public void OnPickUp(int _rodIndex)
        {
            DelegateManager.onSelected?.Invoke(_rodIndex);
            onSelectFeedbacks.PlayFeedbacks();
        }
    }
}