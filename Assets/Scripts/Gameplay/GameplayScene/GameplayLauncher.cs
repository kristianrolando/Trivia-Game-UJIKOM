using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Trivia.GameplayScene
{
    public class GameplayLauncher : MonoBehaviour
    {

        public void GoToLevelScene()
        {
            SceneManager.LoadScene("Level");
        }
        public void GoToPackScene()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}

