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
        public GameObject diskSetupMenu;

        public TimeData timeData;

        public string newGameSceneName;

        private void Start()
        {
            TransitionMenus(mainMenu);
        }

        public void CloseAllMenus()
        {
            mainMenu.SetActive(false);
            loadMenu.SetActive(false);
            settingsMenu.SetActive(false);
            diskSetupMenu.SetActive(false);
        }

        public void TransitionMenus(GameObject _targetMenu)
        {
            CloseAllMenus();
            _targetMenu.SetActive(true);
        }

        public void NewGame()
        {
            TransitionMenus(diskSetupMenu);
        }

        public void LoadGame()
        {
            TransitionMenus(loadMenu);
        }

        public void LoadGameButton()
        {
            TransitionMenus(loadMenu);
        }

        public void Settings()
        {
            TransitionMenus(settingsMenu);
        }

        public void Back()
        {
            TransitionMenus(mainMenu);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}