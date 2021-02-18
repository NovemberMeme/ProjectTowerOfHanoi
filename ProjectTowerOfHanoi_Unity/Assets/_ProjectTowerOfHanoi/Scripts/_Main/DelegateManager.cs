using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace TowerOfHanoi
{
    /// <summary>
    /// Statically provides all needed delegates
    /// </summary>
    public static class DelegateManager 
    {
        /// <summary>
        /// Used by the Tower of Hanoi rods to inform the game system how to handle the disks to play out the game
        /// </summary>
        /// <param name="_rodIndex"></param>
        public delegate void OnSelected(int _rodIndex);
        public static OnSelected onSelected;

        /// <summary>
        /// Used by the feedback system so that a SoundData can be instantiated anywhere in the scene (like in feedbacks)
        /// then its script can simply broadcast this event to initialize the sound with an AudioSource in the AudioManager
        /// which is the primary script listening for this event
        /// </summary>
        /// <param name="_soundData"></param>
        public delegate void InitializeSound(SoundData _soundData);
        public static InitializeSound initializeSound;

        /// <summary>
        /// Used by the feedback system to play a the clip of a SoundData from anywhere
        /// </summary>
        /// <param name="_soundName"></param>
        public delegate void PlaySound(string _soundName);
        public static PlaySound playSound;

        /// <summary>
        /// Used by coroutines which would only change the disk state of the game's currently held disk in the database
        /// upon completion of the coroutine. 
        /// </summary>
        /// <param name="_diskStateData"></param>
        public delegate void OnDiskStateChanged(SO_StateData _diskStateData);
        public static OnDiskStateChanged onDiskStateChanged;

        /// <summary>
        /// Used by menus to set up the disks according to the player's chosen disk count
        /// </summary>
        public delegate void SetDisks(int _diskCount);
        public static SetDisks setupDisks;

        /// <summary>
        /// Used to broadcast a win event
        /// </summary>
        public delegate void Win();
        public static Win win;
    }
}