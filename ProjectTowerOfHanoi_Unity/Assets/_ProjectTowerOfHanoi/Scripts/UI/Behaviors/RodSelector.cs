using UnityEngine;

namespace TowerOfHanoi
{
    public class RodSelector : MonoBehaviour, ISelect
    {
        public FeedbackGroup onSelectFeedbacks;

        public void OnSelect(int _rodIndex)
        {
            DelegateManager.onSelected?.Invoke(_rodIndex);
            onSelectFeedbacks.PlayFeedbacks();
        }
    }
}