using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trivia.SaveData;
using Trivia.Database;
using Trivia.Currency;


namespace Trivia.PackUnlock
{
    public class PackUnlockController : MonoBehaviour
    {
        
        public void UnlockPack(int indexPack, int unlockCost)
        {
            if (CurrencyController.Instance.SpendCoin(unlockCost))
                DatabaseController.Instance.packData[indexPack].isUnLocked = true;
            else
                Debug.Log("Coin gak cukup");
        }
    }

}

