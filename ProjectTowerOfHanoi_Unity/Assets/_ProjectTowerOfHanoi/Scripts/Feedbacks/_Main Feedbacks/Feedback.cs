using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Feedback : MonoBehaviour
    {
        public SoundData SoundToPlay;

        private void Start()
        {
            //Debug.Log("Delegate broadcasted?");
            DelegateManager.initializeSound?.Invoke(SoundToPlay);
            if (SoundToPlay.PlayOnAwake)
                PlaySounds();
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