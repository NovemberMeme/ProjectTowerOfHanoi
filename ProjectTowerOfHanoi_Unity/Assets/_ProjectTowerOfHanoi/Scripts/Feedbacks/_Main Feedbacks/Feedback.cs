using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    public class Feedback : MonoBehaviour
    {
        public SoundData SoundToPlay;
        public ParticleSystem ParticleFX;
        public Animator FeedbackAnimator;
        public string FeedbackAnimationTrigger;
        public bool PlayAnimationOnStart = false;

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

            if (PlayAnimationOnStart &&
                FeedbackAnimator != null)
                PlayAnimation();
        }

        public void PlayFeedback()
        {
            PlaySounds();
            PlayParticleFX();
            PlayAnimation();
        }

        public void StopFeedback()
        {
            StopSounds();
            StopParticleFX();
            StopAnimation();
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
        }

        private void StopParticleFX()
        {
            if (ParticleFX != null)
                ParticleFX.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        private void PlayAnimation()
        {
            FeedbackAnimator.SetTrigger(FeedbackAnimationTrigger);
        }

        private void StopAnimation()
        {

        }
    }
}