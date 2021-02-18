using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// There is only one IPickUp inheritor which is RodPickUp. Although it could have been simpler to just make
    /// the RodPickUp behavior a simpler single class/function rather than a class/interface pairing, this allows 
    /// precise control when using GetComponent<IPickUp> and also allows future varying IPickUp behaviors to be
    /// easily created and defined.
    /// Whichever monobehavior that inherits from IPickUp will be detected by the InteractionHandler and used in its functions.
    /// </summary>
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