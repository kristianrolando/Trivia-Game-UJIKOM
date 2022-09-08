using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Trivia.Database;
using System;
using Trivia.SaveData;

namespace Trivia.PackData
{
    public class PackDataView : MonoBehaviour
    {
        [SerializeField]
        private Sprite completeImage;
        [SerializeField]
        private Transform parentButton;
        [SerializeField]
        private GameObject prefButton;
        [SerializeField]
        private TextMeshProUGUI coinText;

        private void Awake()
        {
            CreateButton();
            coinText.text = SaveDataModel.Instance.LoadCoin().ToString();
        }

        void CreateButton()
        {
            var j = DatabaseController.Instance.packData.Length;
            GameObject[] _button = new GameObject[j];
            var data = DatabaseController.Instance;
            for (int i = 0; i < j; i++)
            {
                // create button
                _button[i] = Instantiate(prefButton, parentButton);
                TextMeshProUGUI[] obj = _button[i].GetComponentsInChildren<TextMeshProUGUI>();
                // set id pack text
                TextMeshProUGUI label = Array.Find(obj, obj => obj.name == "IdPack");
                label.text = data.packData[i].name.ToString();
                // set completed image
                Image[] im = _button[i].GetComponentsInChildren<Image>();
                Image _image = Array.Find(im, im => im.name == "CompletedImage");
                _image.sprite = completeImage;
                // set unlock text
                TextMeshProUGUI[] _b = _button[i].GetComponentsInChildren<TextMeshProUGUI>();
                TextMeshProUGUI unlock = Array.Find(_b, _b => _b.name == "UnlockText");
                unlock.text = data.packData[i].unlockCost.ToString();

                /*
                //set lock button
                if(!data.packData[i].isUnLocked)
                {
                    Button _objButton = _button[i].GetComponentInChildren<Button>();
                    _objButton.interactable = false;
                    //Image _objImage = _button[i].GetComponentInChildren<Image>();
                    //_objImage.gameObject.SetActive(false);
                    unlock.gameObject.SetActive(true);
                }
                else
                {
                    Button _objButton = _button[i].GetComponentInChildren<Button>();
                    _objButton.interactable = true;
                    unlock.gameObject.SetActive(false);
                }


                // set completed image
                if(data.packData[i].isCompleted)
                {
                    Image _objImage = _button[i].GetComponentInChildren<Image>();
                    _objImage.gameObject.SetActive(true);
                }
                else
                {
                    Image _objImage = _button[i].GetComponentInChildren<Image>();
                    _objImage.gameObject.SetActive(false);
                }
                */
            }
        }
    }
}
