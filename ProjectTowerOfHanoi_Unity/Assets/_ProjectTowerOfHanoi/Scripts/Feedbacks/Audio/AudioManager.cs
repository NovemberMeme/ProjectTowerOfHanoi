using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

namespace TowerOfHanoi
{
    public class AudioManager : MonoBehaviour
    {
        public DataBaseSO DB;
        public List<SoundData> SoundList = new List<SoundData>();

        private void Awake()
        {
            DelegateManager.initializeSound += InitializeSound;
            DelegateManager.playSound += PlaySound;
        }

        private void OnEnable()
        {
            Debug.Log("Check");
        }

        private void OnDisable()
        {
            DelegateManager.initializeSound -= InitializeSound;
            DelegateManager.playSound -= PlaySound;
        }

        private void Start()
        {
            //for (int i = 0; i < DB.GameFeedbacks.Count; i++)
            //{
            //    for (int j = 0; j < DB.GameFeedbacks[i].Feedbacks.Length; j++)
            //    {
            //        SoundData _soundData = DB.GameFeedbacks[i].Feedbacks[j].SoundToPlay;
            //        _soundData.Source = gameObject.AddComponent<AudioSource>();
            //        _soundData.Source.clip = _soundData.Clip;

            //        _soundData.Source.volume = _soundData.Volume;
            //        _soundData.Source.pitch = _soundData.Pitch;
            //        _soundData.Source.loop = _soundData.Loop;
            //        _soundData.Source.playOnAwake = _soundData.PlayOnAwake;
            //        //SoundList.Add(DB.GameFeedbacks[i].Feedbacks[j].SoundToPlay);
            //        //ForceInitializeSound(DB.GameFeedbacks[i].Feedbacks[j].SoundToPlay, true);
            //    }
            //}
            InitializeAllSounds();
        }

        public void InitializeSound(SoundData _soundData)
        {
            //Debug.Log("Delegate Called?");

            if (!SoundList.Contains(_soundData))
            {
                //Debug.Log("Add?");
                SoundList.Add(_soundData);
                _soundData.Source = gameObject.AddComponent<AudioSource>();
                _soundData.Source.clip = _soundData.Clip;

                _soundData.Source.volume = _soundData.Volume;
                _soundData.Source.pitch = _soundData.Pitch;
                _soundData.Source.loop = _soundData.Loop;
                _soundData.Source.playOnAwake = _soundData.PlayOnAwake;
                RefreshSounds();
            }
        }

        public void ForceInitializeSound(SoundData _soundData, bool _forceInitialize)
        {
            if (!_forceInitialize)
                return;

            SoundList.Add(_soundData);
            _soundData.Source = gameObject.AddComponent<AudioSource>();
            _soundData.Source.clip = _soundData.Clip;

            _soundData.Source.volume = _soundData.Volume;
            _soundData.Source.pitch = _soundData.Pitch;
            _soundData.Source.loop = _soundData.Loop;
            _soundData.Source.playOnAwake = _soundData.PlayOnAwake;
            RefreshSounds();
        }

        private void RefreshSounds()
        {
            List<SoundData> currentListSnapshot = new List<SoundData>(SoundList);

            foreach (SoundData s in currentListSnapshot)
            {
                if (s.Source == null)
                    InitializeSound(s);
            }
        }

        private void InitializeAllSounds()
        {
            List<SoundData> currentListSnapshot = new List<SoundData>(SoundList);

            foreach (SoundData s in currentListSnapshot)
            {
                if (s.Source == null)
                    ForceInitializeSound(s, true);
            }
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