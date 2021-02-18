using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// This script is meant to initialize all the feedback group prefabs assigned to the database
    /// </summary>
    public class FeedbackManager : MonoBehaviour
    {
        public Transform FeedbackHolder;
        public DataBaseSO DB;

        private void OnEnable()
        {
            DelegateManager.win += Win;
        }

        private void OnDisable()
        {
            DelegateManager.win -= Win;
        }

        private void Start()
        {
            InitializeFeedbacks();
        }

        /// <summary>
        /// For each feedback group prefab in the database list, it instantiates it as a child of the FeedbackHolder.
        /// If there is no FeedbackHolder assigned then it uses itself as the FeedbackHolder
        /// </summary>
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

        private void Win()
        {
            FeedbackHolder.GetChild(0).GetComponent<FeedbackGroup>().PlayFeedbacks();
        }
    }
}