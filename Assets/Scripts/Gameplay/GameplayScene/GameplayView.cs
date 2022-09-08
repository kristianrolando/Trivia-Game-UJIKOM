using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Trivia.GameplayScene
{
    public class GameplayView : MonoBehaviour
    {
        [SerializeField]
        private GameplayLauncher launch;
        [SerializeField]
        private Button backButton;

        private void Start()
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(launch.GoToLevelScene);
        }


    }
}

