using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerOfHanoi
{
    /// <summary>
    /// The individual element of the feedback system. 
    /// It can have up to one sound (SoundData), up to one particle system, and and up to one animation.
    /// It does not need to have all fields filled in order to work i.e. there can be pure SFX feedbacks
    /// or pure particle system feedbacks.
    /// </summary>
    public class Feedback : MonoBehaviour
    {
        public SoundData SoundToPlay;
        public ParticleSystem ParticleFX;
        public GameObject ParticleFXPrefab;
        public bool shouldInstantiateParticleFX;
        public Animator FeedbackAnimator;
        public string FeedbackAnimationTrigger;
        public bool PlayAnimationOnStart = false;

        private void Start()
        {
            //Debug.Log("Delegate broadcasted?");
            DelegateManager.initializeSound?.Invoke(SoundToPlay);
            if (SoundToPlay.PlayOnAwake)
                PlaySounds();

            StopParticleFX();

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

        /// <summary>
        /// Differentiates between particle FX that require spawning every time
        /// </summary>
        private void PlayParticleFX()
        {
            if(ParticleFX != null)
            {
                if (shouldInstantiateParticleFX)
                {
                    GameObject FXobject = Instantiate(ParticleFXPrefab, transform.position, Quaternion.identity);
                    ParticleSystem FX = FXobject.GetComponent<ParticleSystem>();
                    ChildController FXcontroller = FXobject.GetComponent<ChildController>();
                    if (FXcontroller != null)
                        FXcontroller.SetChildrenActive(true);
                    FX.Play(true);
                }
                else
                {
                    ChildController controller = ParticleFX.GetComponent<ChildController>();
                    if (controller != null)
                        controller.SetChildrenActive(true);
                    ParticleFX.Play(true);
                }
            }
        }

        private void StopParticleFX()
        {
            if (ParticleFX != null)
            {
                ParticleFX.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                ChildController controller = ParticleFX.GetComponent<ChildController>();
                if (controller != null)
                    controller.SetChildrenActive(false);
            }
        }

        private void PlayAnimation()
        {
            if(FeedbackAnimator != null)
                FeedbackAnimator.SetTrigger(FeedbackAnimationTrigger);
        }

        private void StopAnimation()
        {

        }
    }
}