using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Trivia.Database;
using TMPro;
using System;
using Trivia.PackUnlock;

public class PackView : MonoBehaviour
{

    [SerializeField]
    private PackLauncher launch;
    [SerializeField]
    private PackUnlockController packUnlock;


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
        var tempDatabase = DatabaseController.Instance;
        int le = DatabaseController.Instance.packData.Length;

        Button[] obj = parentButton.GetComponentsInChildren<Button>();

        for(int i = 0; i < le; i++)
        {
            //TextMeshProUGUI[] _idPack = obj[i].GetComponentsInChildren<TextMeshProUGUI>();
            //TextMeshProUGUI _name = Array.Find(_idPack, id => id.name == "IdPack");
            //string idPack = _name.ToString();
            int _unlockCost = DatabaseController.Instance.packData[i].unlockCost;
            obj[i].onClick.RemoveAllListeners();
            obj[i].name = "button  " + i;
            if(!tempDatabase.packData[i].isUnLocked)
                obj[i].onClick.AddListener(() => packUnlock.UnlockPack(i, _unlockCost));
            else
                obj[i].onClick.AddListener(() => launch.SelectPack(i));
        }

    }

}
