using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Feedback : MonoBehaviour
    {
        public SoundData SoundToPlay;
        public ParticleSystem ParticleFX;

        private void Start()
        {
            //Debug.Log("Delegate broadcasted?");
            DelegateManager.initializeSound?.Invoke(SoundToPlay);
            if (SoundToPlay.PlayOnAwake)
                PlaySounds();

            if (ParticleFX != null)
            {
                ParticleFX?.Pause();
            }
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
            ParticleFX?.Play();
            //ParticleFX?.SetActive(true);
        }

        private void StopParticleFX()
        {
            ParticleFX?.Pause();
            //ParticleFX?.SetActive(false);
        }
    }
}