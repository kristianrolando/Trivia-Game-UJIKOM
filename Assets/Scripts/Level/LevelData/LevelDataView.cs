using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Trivia.Database;
using System;
using Trivia.SaveData;

namespace Trivia.LevelData
{
    public class LevelDataView : MonoBehaviour
    {
        [SerializeField]
        private Sprite completeImage;
        [SerializeField]
        private Transform parentButton;
        [SerializeField]
        private GameObject prefButton;

        private void Start()
        {
            CreateButton();
        }

        void CreateButton()
        {
            int packID = PlayerPrefs.GetInt("PackIDSelected");
            packID -= 1;
            var j = DatabaseController.Instance.packData[packID].level.Length;
            GameObject[] _button = new GameObject[j];
            var data = DatabaseController.Instance.packData[packID];
            for (int i = 0; i < j; i++)
            {
                // create button
                _button[i] = Instantiate(prefButton, parentButton);
                TextMeshProUGUI[] obj = _button[i].GetComponentsInChildren<TextMeshProUGUI>();
                // set id level text
                TextMeshProUGUI label = Array.Find(obj, obj => obj.name == "IdLevel");
                label.text = data.level[i].levelID.ToString();
                // set completed image
                Image[] im = _button[i].GetComponentsInChildren<Image>();
                Image _image = Array.Find(im, im => im.name == "CompletedImage");
                _image.sprite = completeImage;
            }
        }
    }

}
