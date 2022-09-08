using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Trivia.Database;
using TMPro;
using System;
using Trivia.PackUnlock;


namespace Trivia.LevelScene
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField]
        private LevelLauncher launch;


        [SerializeField]
        private Button backButton;
        [SerializeField]
        private GameObject parentButton;

        private void Start()
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(launch.GoBack);
            GetEventButtonSelection();
        }
        void GetEventButtonSelection()
        {
            int packID = PlayerPrefs.GetInt("PackIDSelected");
            packID -= 1;
            var tempDatabase = DatabaseController.Instance;
            int le = DatabaseController.Instance.packData[packID].level.Length;

            var obj = parentButton.GetComponentsInChildren<Button>();

            for (int i = 0; i < le; i++)
            {
                //TextMeshProUGUI[] _idPack = obj[i].GetComponentsInChildren<TextMeshProUGUI>();
                //TextMeshProUGUI _name = Array.Find(_idPack, id => id.name == "IdPack");
                //string idPack = _name.ToString();
                int _unlockCost = DatabaseController.Instance.packData[i].unlockCost;

                obj[i].onClick.RemoveAllListeners();
                obj[i].onClick.AddListener(() => launch.SelectLevel(i));
            }

        }
    }
    
}

