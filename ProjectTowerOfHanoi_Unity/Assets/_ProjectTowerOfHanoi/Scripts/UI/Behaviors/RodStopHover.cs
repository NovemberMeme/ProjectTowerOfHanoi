using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodStopHover : MonoBehaviour, IStopHover
    {
        public FeedbackGroup FeedbacksToStart;
        public FeedbackGroup FeedbacksToStop;

        public void OnStopHover()
        {
            FeedbacksToStop?.StopFeedbacks();
            FeedbacksToStart?.PlayFeedbacks();
        }
    }
}