using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace TowerOfHanoi
{
    /// <summary>
    /// Holds all the public functions for adjusting the auxiliary game settings rather than the gameplay settings.
    /// </summary>
    public class SettingsMenu : MonoBehaviour
    {
        public VolumeProfile GlobalVolumeProfile;
        private ColorAdjustments colorAdjustments;

        public AudioMixer MainMixer;

        public TMP_Dropdown resolutionDropDown;

        Resolution[] resolutions;

        private void Start()
        {
            InitializeResolutions();
            GlobalVolumeProfile.TryGet<ColorAdjustments>(out ColorAdjustments component);
            colorAdjustments = component;
        }

        /// <summary>
        /// Dynamically creates a list of the current device's available resolutions and adds them to the dropdown's list
        /// </summary>
        private void InitializeResolutions()
        {
            resolutions = Screen.resolutions;

            resolutionDropDown.ClearOptions();

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width &&
                    resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            resolutionDropDown.AddOptions(options);
            resolutionDropDown.value = currentResolutionIndex;
            resolutionDropDown.RefreshShownValue();
        }

        public void SetResolution(int resolutionIndex)
        {
            Resolution resolution = resolutions[resolutionIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void SetFullScreen(bool isFullScreen)
        {
            Screen.fullScreen = isFullScreen;
        }

        public void SetMasterVolume(float _volume)
        {
            MainMixer.SetFloat("MasterVolume", _volume);
        }

        public void SetMusicVolume(float _volume)
        {
            MainMixer.SetFloat("MusicVolume", _volume);
        }

        public void SetSFXVolume(float _volume)
        {
            MainMixer.SetFloat("SFXVolume", _volume);
        }

        public void SetBrightness(float _brightness)
        {
            colorAdjustments.postExposure.value = _brightness;
        }
    }
}