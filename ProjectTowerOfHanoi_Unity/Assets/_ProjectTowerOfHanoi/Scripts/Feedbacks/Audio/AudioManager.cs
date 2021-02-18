using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace TowerOfHanoi
{
    /// <summary>
    /// Holds all initialized audio sources of all initialized sounds (in the form of SoundData).
    /// Listens to globally broadcasted initializeSound events because Audio sources can be initialized from elsewhere 
    /// instead of just this script's SoundList. Listens to globally broadcasted playSound events to play requested sounds.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {
        public DataBaseSO DB;
        public List<SoundData> SoundList = new List<SoundData>();

        private void Awake()
        {
            
        }

        private void OnEnable()
        {
            DelegateManager.initializeSound += InitializeSound;
            DelegateManager.playSound += PlaySound;
        }

        private void OnDisable()
        {
            DelegateManager.initializeSound -= InitializeSound;
            DelegateManager.playSound -= PlaySound;
        }

        private void Start()
        {
            RefreshSounds();
        }

        /// <summary>
        /// Creates a new AudioSource component on the gameobject this script is assigned for the inputted SoundData
        /// Initializes the AudioSource fields using SoundData fields
        /// </summary>
        /// <param name="_soundData"></param>
        public void InitializeSound(SoundData _soundData)
        {
            if (!SoundList.Contains(_soundData))
            {
                SoundList.Add(_soundData);
                _soundData.Source = gameObject.AddComponent<AudioSource>();
                _soundData.Source.clip = _soundData.Clip;
                _soundData.Source.outputAudioMixerGroup = _soundData.OutputGroup;

                _soundData.Source.volume = _soundData.Volume;
                _soundData.Source.pitch = _soundData.Pitch;
                _soundData.Source.loop = _soundData.Loop;
                _soundData.Source.playOnAwake = _soundData.PlayOnAwake;
                RefreshSounds();
            }
        }

        /// <summary>
        /// Makes sure all sounds are initialized by creating a copy of the current SoundList and initializes all sounds in that list.
        /// It creates a copy to avoid list problems when adding to the list while looping through it.
        /// </summary>
        private void RefreshSounds()
        {
            List<SoundData> currentListSnapshot = new List<SoundData>(SoundList);

            foreach (SoundData s in currentListSnapshot)
            {
                if (s.Source == null)
                    InitializeSound(s);
            }
        }

        /// <summary>
        /// Plays a sound based on input string.
        /// The input string must be the clip name of the sound to play which avoids spelling errors
        /// </summary>
        /// <param name="_soundName"></param>
        public void PlaySound(string _soundName)
        {
            for (int i = 0; i < SoundList.Count; i++)
            {
                if (SoundList[i].Clip == null)
                    continue;

                if(SoundList[i].Clip.name == _soundName)
                {
                    SoundData s = SoundList[i];
                    s.Source.Play();
                    return;
                }
            }

            Debug.LogWarning("Sound: " + _soundName + "does not exist");
        }
    }
}