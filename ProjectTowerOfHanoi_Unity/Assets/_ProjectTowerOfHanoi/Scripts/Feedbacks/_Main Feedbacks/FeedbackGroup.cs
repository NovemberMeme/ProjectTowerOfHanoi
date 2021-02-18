using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// Groups feedbacks together so that a defined set of feedbacks can be saved as one prefab
    /// </summary>
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

        /// <summary>
        /// Plays all the feedbacks in the list, this can be modified in the future to have sequencing logic
        /// </summary>
        [ContextMenu("Play Feedbacks")]
        public void PlayFeedbacks()
        {
            for (int i = 0; i < Feedbacks.Length; i++)
            {
                Feedbacks[i].PlayFeedback();
            }
        }

        /// <summary>
        /// Stops all the feedbacks in the list, usually to end loops
        /// </summary>
        public void StopFeedbacks()
        {
            for (int i = 0; i < Feedbacks.Length; i++)
            {
                Feedbacks[i].StopFeedback();
            }
        }
    }
}