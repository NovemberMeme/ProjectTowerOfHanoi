using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class FeedbackManager : MonoBehaviour
    {
        public Transform FeedbackHolder;
        public DataBaseSO DB;

        private void OnEnable()
        {
            InitializeFeedbacks();
        }

        private void InitializeFeedbacks()
        {
            if (FeedbackHolder == null)
                FeedbackHolder = transform;

            for (int i = 0; i < DB.GameFeedbacks.Count; i++)
            {
                GameObject newFBGroupObject = Instantiate(
                    DB.GameFeedbacks[i].gameObject, 
                    transform.position, 
                    Quaternion.identity, 
                    FeedbackHolder);
            }
        }
    }
}