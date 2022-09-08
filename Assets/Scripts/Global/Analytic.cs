using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Trivia.PubSub;

namespace Trivia.Analytic
{
    public class Analytic : MonoBehaviour
    {
        public static Analytic Instance;
        private void Awake()
        {
            Instance = this;
            PublishSubscribe.Instance.Subscribe<FinishLevel>(SendDataLevel);

        }

        public void SendDataLevel(FinishLevel message)
        {
            Debug.Log("Level: " + message.levelID);
        }
        public void SendDataPack(string pack)
        {
            Debug.Log("Pack: " + pack);
        }


    }
}
