using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TowerOfHanoi
{
    [System.Serializable]
    public class SoundData
    {
        public AudioClip Clip;

        [Range(0f, 1f)]
        public float Volume = 1;
        [Range(0.1f, 3f)]
        public float Pitch = 1;

        public bool Loop;
        public bool PlayOnAwake;

        [HideInInspector]
        public AudioSource Source;

        public AudioMixerGroup OutputGroup;

        public SoundData(SoundData _copy)
        {
            if(_copy.Clip != null)
                Clip = _copy.Clip;
            if(_copy.Source != null)
                Source = _copy.Source;

            Volume = _copy.Volume;
            Pitch = _copy.Pitch;
            Loop = _copy.Loop;
            PlayOnAwake = _copy.PlayOnAwake;
        }
    }
}