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
                ParticleFX.Stop(true, ParticleSystemStopBehavior.StopEmitting);
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
            if(SoundToPlay.Clip != null)
                DelegateManager.playSound?.Invoke(SoundToPlay.Clip.name);
        }

        private void StopSounds()
        {

        }

        private void PlayParticleFX()
        {
            if(ParticleFX != null)
                ParticleFX.Play(true);
            //ParticleFX?.SetActive(true);
        }

        private void StopParticleFX()
        {
            if (ParticleFX != null)
                ParticleFX.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            //ParticleFX?.SetActive(false);
        }
    }
}