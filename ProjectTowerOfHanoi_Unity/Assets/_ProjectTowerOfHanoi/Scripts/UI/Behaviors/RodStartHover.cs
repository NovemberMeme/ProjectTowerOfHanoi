﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodStartHover : MonoBehaviour, IStartHover
    {
        public FeedbackGroup FeedbacksToStart;
        public FeedbackGroup FeedbacksToStop;

        public void OnStartHover()
        {
            FeedbacksToStop?.StopFeedbacks();
            FeedbacksToStart?.PlayFeedbacks();
        }
    }
}