using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WereAllGonnaDieAnywayNew
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject loadMenu;
        public GameObject settingsMenu;

        public TimeData timeData;

        public string newGameSceneName;

        private void Start()
        {
            TransitionToMainMenu();
        }

        public void TransitionToMainMenu()
        {
            mainMenu.SetActive(true);
            loadMenu.SetActive(false);
            settingsMenu.SetActive(false);
        }

        public void TransitionToLoadMenu()
        {
            mainMenu.SetActive(false);
            settingsMenu.SetActive(false);

            loadMenu.SetActive(true);
        }

        public void TransitionToSettingsMenu()
        {
            mainMenu.SetActive(false);
            loadMenu.SetActive(false);

            settingsMenu.SetActive(true);
        }

        public void NewGame()
        {
            SceneManager.LoadScene(newGameSceneName);
            timeData.ShouldLoad = false;
        }

        public void LoadGame()
        {
            SceneManager.LoadScene(newGameSceneName);
            timeData.ShouldLoad = true;
        }

        public void LoadGameButton()
        {
            TransitionToLoadMenu();
        }

        public void Settings()
        {
            TransitionToSettingsMenu();
        }

        public void Back()
        {
            TransitionToMainMenu();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}