using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Trivia.LevelScene
{
    public class LevelLauncher : MonoBehaviour
    {
        public void GoBack()
        {
            SceneManager.LoadScene("Home");
        }
        public void SelectLevel (int levelID)
        {
            PlayerPrefs.SetInt("LevelIDSelected", levelID);
            SceneManager.LoadScene("Gameplay");
        }
    }
}

