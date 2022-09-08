using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Trivia.Database;
using Agate.MVC.Core;
using Trivia.PubSub;
using Trivia.Analytic;
using Trivia.GameplayScene;
using Trivia.Currency;

namespace Trivia.GameFlow
{
    public class GameFlowController : MonoBehaviour
    {
        [SerializeField]
        private GameplayLauncher launch;
        string answer;
        private void Awake()
        {
            PublishSubscribe.Instance.Subscribe<AnswerClick>(AnswerQuestion);
        }
        private void OnDestroy()
        {
            PublishSubscribe.Instance.Unsubscribe<AnswerClick>(AnswerQuestion);
        }
        private void Start()
        {
            int idLevel = PlayerPrefs.GetInt("LevelIDSelected");
            int idPack = PlayerPrefs.GetInt("PackIDSelected");
            idLevel -= 1;
            idPack -= 1;
            answer = DatabaseController.Instance.packData[idPack].level[idLevel].answer;
        }

        public void AnswerQuestion(AnswerClick message)
        {
            int idLevel = PlayerPrefs.GetInt("LevelIDSelected");
            int idPack = PlayerPrefs.GetInt("PackIDSelected");
            idLevel -= 1;
            idPack -= 1;

            if (this.answer == message.answer)
            {
                int k = 0;
                var temp = DatabaseController.Instance.packData[idPack].level[idLevel];
                for (int i = 0; i < DatabaseController.Instance.packData[idPack].level.Length; i++)
                {
                    if(temp.isFinished)
                    {
                        k++;
                        launch.GoToPackScene();
                    }
                    if(k == DatabaseController.Instance.packData[idPack].level.Length)
                    {
                        Debug.Log("Semua Level Completed");
                        PublishSubscribe.Instance.Publish<FinishLevel>(new FinishLevel(temp.levelID));
                    }
                }
                if(!temp.isFinished)
                {
                    temp.isFinished = true;
                    CurrencyController.Instance.AddCoin(100);
                }
                PublishSubscribe.Instance.Publish<FinishLevel>(new FinishLevel(temp.levelID));

                Debug.Log("Jawaban Benar");
            }
            else
            {
                launch.GoToLevelScene();
                Debug.Log("Jawaban Salah");
            }
        }

        
    }
}

