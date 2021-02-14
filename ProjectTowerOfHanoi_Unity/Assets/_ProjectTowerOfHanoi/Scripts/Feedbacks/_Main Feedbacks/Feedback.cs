using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Feedback : MonoBehaviour
    {
        public SoundData SoundToPlay;

        private void OnEnable()
        {
            Debug.Log("Delegate broadcasted?");
            DelegateManager.initializeSound?.Invoke(SoundToPlay);
        }

        public void PlayFeedback()
        {
            PlaySounds();
        }

        private void PlaySounds()
        {
            DelegateManager.playSound?.Invoke(SoundToPlay.Clip.name);
        }
    }
}