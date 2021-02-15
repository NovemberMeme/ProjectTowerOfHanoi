using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodStartHover : MonoBehaviour, IStartHover
    {
        public FeedbackGroup onStartHoverFeedbacks;

        public void OnStartHover()
        {
            onStartHoverFeedbacks?.PlayFeedbacks();
        }
    }
}