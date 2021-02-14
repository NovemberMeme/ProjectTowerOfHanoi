using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TowerOfHanoi
{
    public static class DelegateManager 
    {
        public delegate void OnSelected(int _rodIndex);
        public static OnSelected onSelected;

        public delegate void InitializeSound(SoundData _soundData);
        public static InitializeSound initializeSound;

        public delegate void PlaySound(string _soundName);
        public static PlaySound playSound;
    }
}