using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodStopHover : MonoBehaviour, IStopHover
    {
        public FeedbackGroup OnStopHoverFeedbacks;

        public void OnStopHover()
        {
            OnStopHoverFeedbacks.PlayFeedbacks();
        }
    }
}