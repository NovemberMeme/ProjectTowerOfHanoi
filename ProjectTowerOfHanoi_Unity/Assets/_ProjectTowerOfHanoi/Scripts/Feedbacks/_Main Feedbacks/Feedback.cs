using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Feedback : MonoBehaviour
    {
        public SoundData SoundToPlay;
        public GameObject ParticleFX;

        private void Start()
        {
            //Debug.Log("Delegate broadcasted?");
            DelegateManager.initializeSound?.Invoke(SoundToPlay);
            if (SoundToPlay.PlayOnAwake)
                PlaySounds();

            if (ParticleFX != null)
                ParticleFX.SetActive(false);
        }

        public void PlayFeedback()
        {
            PlaySounds();
            PlayParticleFX();
        }

        public void StopFeedback()
        {
            StopSounds();
            StopParticleFX();
        }

        private void PlaySounds()
        {
            DelegateManager.playSound?.Invoke(SoundToPlay.Clip.name);
        }

        private void StopSounds()
        {

        }

        private void PlayParticleFX()
        {
            ParticleFX?.SetActive(true);
        }

        private void StopParticleFX()
        {
            ParticleFX?.SetActive(false);
        }
    }
}