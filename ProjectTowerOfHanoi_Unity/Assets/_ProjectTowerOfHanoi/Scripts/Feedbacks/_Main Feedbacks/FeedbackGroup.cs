using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class FeedbackGroup : MonoBehaviour
    {
        public Transform FeedbacksTransform;
        public Feedback[] Feedbacks;

        private void Awake()
        {
            if (FeedbacksTransform != null)
                Feedbacks = FeedbacksTransform.GetComponents<Feedback>();
            else
                Feedbacks = GetComponents<Feedback>();
        }

        [ContextMenu("Play Feedbacks")]
        public void PlayFeedbacks()
        {
            for (int i = 0; i < Feedbacks.Length; i++)
            {
                Feedbacks[i].PlayFeedback();
            }
        }
    }
}