using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodPlace : MonoBehaviour, IPlace
    {
        public FeedbackGroup OnPlaceFeedbacks;

        public void OnPlace()
        {
            OnPlaceFeedbacks.PlayFeedbacks();
        }
    }
}