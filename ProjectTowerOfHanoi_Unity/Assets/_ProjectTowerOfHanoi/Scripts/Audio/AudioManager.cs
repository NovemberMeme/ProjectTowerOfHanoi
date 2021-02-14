using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace TowerOfHanoi
{
    public class AudioManager : MonoBehaviour
    {
        public List<SoundData> SoundList = new List<SoundData>();

        private void Awake()
        {
            foreach (SoundData s in SoundList)
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;

                s.Source.volume = s.Volume;
                s.Source.pitch = s.Pitch;
                s.Source.loop = s.Loop;
                s.Source.playOnAwake = s.PlayOnAwake;
            }
        }

        private void Start()
        {
            for (int i = 0; i < SoundList.Count; i++)
            {
                if (SoundList[i].PlayOnAwake)
                    PlaySound(SoundList[i].Clip.name);
            }
        }

        private void OnEnable()
        {
            DelegateManager.playSound += PlaySound;
        }

        private void OnDisable()
        {
            DelegateManager.playSound -= PlaySound;
        }

        public void PlaySound(string _soundName)
        {
            for (int i = 0; i < SoundList.Count; i++)
            {
                if(SoundList[i].Clip.name == _soundName)
                {
                    SoundData s = SoundList[i];
                    s.Source.Play();
                    return;
                }
            }

            Debug.LogWarning("Sound: " + _soundName + "does not exist");
        }

        [ContextMenu("Name")]
        public void SayName()
        {
            SoundList[0].Source.clip = SoundList[0].Clip;
            PlaySound(SoundList[0].Source.clip.name);
            Debug.Log(SoundList[0].Source.clip.name);
        }
    }
}