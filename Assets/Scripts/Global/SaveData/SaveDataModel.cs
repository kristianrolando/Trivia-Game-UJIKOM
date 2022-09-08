using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trivia.SaveData
{
    public class SaveDataModel : MonoBehaviour
    {
        public static SaveDataModel Instance;
        int coin;
        string[] unLockedPack;
        string[] completedPack;
        string[] completedLevel;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SaveCoin(int coin)
        {
            PlayerPrefs.SetInt("coin", coin);
        }
        public int LoadCoin()
        {
            return PlayerPrefs.GetInt("coin");
        }


    }
}
