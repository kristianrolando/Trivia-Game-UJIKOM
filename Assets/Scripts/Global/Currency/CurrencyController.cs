using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trivia.SaveData;


namespace Trivia.Currency
{
    public class CurrencyController : MonoBehaviour
    {
        public static CurrencyController Instance;
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
        public void AddCoin(int amount)
        {
            int temp = amount + SaveDataModel.Instance.LoadCoin();
            SaveDataModel.Instance.SaveCoin(temp);
        }
        public bool SpendCoin(int amount)
        {
            int temp = SaveDataModel.Instance.LoadCoin();
            temp -= amount;
            if (temp < 0)
                return false;
            else
                return true;

        }
    }
}

