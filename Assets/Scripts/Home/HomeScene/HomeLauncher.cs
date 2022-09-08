using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Trivia.HomeScene
{
    public class HomeLauncher : MonoBehaviour
    {
        public void StartPlay()
        {
            SceneManager.LoadScene("Pack");
        }
    }
}

