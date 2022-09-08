using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace Trivia.HomeScene
{
    public class HomeView : MonoBehaviour
    {
        [SerializeField]
        Button playButton;
        [SerializeField]
        HomeLauncher launch;
        private void Awake()
        {
            playButton.onClick.RemoveAllListeners();
            playButton.onClick.AddListener(launch.StartPlay);
        }

    }
}

