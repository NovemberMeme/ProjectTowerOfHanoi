using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class RodStartHover : MonoBehaviour, IStartHover
    {
        public DataBaseSO DB;

        public FeedbackGroup FeedbacksToStart;
        public FeedbackGroup FeedbacksToStop;

        public void OnStartHover()
        {
            FeedbacksToStop?.StopFeedbacks();
            FeedbacksToStart?.PlayFeedbacks();
            StartCoroutine(_BeginHoverSFXCooldown());
        }

        private IEnumerator _BeginHoverSFXCooldown()
        {
            DB.IsOnHoverCooldown = true;
            yield return new WaitForSeconds(DB.HoverSFXCooldown);
            DB.IsOnHoverCooldown = false;
        }
    }
}