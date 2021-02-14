using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
}