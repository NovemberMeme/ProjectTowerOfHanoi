using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class SimpleClick : IClick
    {
        public FeedbackGroup FeedbacksToStart;
        public FeedbackGroup FeedbacksToStop;

        public void OnClick()
        {
            FeedbacksToStop?.StopFeedbacks();
            FeedbacksToStart?.PlayFeedbacks();
        }
    }
}