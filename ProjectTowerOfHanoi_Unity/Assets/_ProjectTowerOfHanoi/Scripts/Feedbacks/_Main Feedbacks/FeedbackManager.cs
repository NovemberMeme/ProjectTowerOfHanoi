using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class FeedbackManager : MonoBehaviour
    {
        public Transform FeedbackHolder;
        public DataBaseSO DB;

        private void Start()
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

                //FeedbackGroup newFBGroup = newFBGroupObject.GetComponent<FeedbackGroup>();

                //for (int j = 0; j < newFBGroup.Feedbacks.Length; j++)
                //{
                //    newFBGroup.Feedbacks[j].SoundToPlay = new SoundData(newFBGroup.Feedbacks[j].SoundToPlay);
                //    DelegateManager.initializeSound.Invoke(newFBGroup.Feedbacks[j].SoundToPlay);
                //    Debug.Log("Invoked " + newFBGroup.Feedbacks[j].SoundToPlay.Clip.name);
                //}
            }
        }
    }
}