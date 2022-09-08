using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Trivia.Database;
using Agate.MVC.Core;
using Trivia.PubSub;

namespace Trivia.Quiz
{
    public class QuizView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI questionText;
        [SerializeField]
        private Image hintImage;
        [SerializeField]
        private Button[] answerButtons;

        private void Start()
        {
            LoadQuestion();
            GetEventButton();
        }
        
        void GetEventButton()
        {
            for (int i = 0; i < answerButtons.Length; i++)
            {
                string _answer = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().ToString();

                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(()=>OnClickAnswer(_answer));
            }
        }
        void OnClickAnswer(string answer)
        {
            Debug.Log("Publish");
            PublishSubscribe.Instance.Publish<AnswerClick>(new AnswerClick(answer));

        }



        void LoadQuestion()
        {
            int idLevel = PlayerPrefs.GetInt("LevelIDSelected");
            int idPack = PlayerPrefs.GetInt("PackIDSelected");
            idLevel -= 1;
            idPack -= 1;

            var j = DatabaseController.Instance.packData[idPack].level[idLevel];
            var k = DatabaseController.Instance.packData[idPack].level[idLevel].Choice.Length;

            // load answer
            TextMeshProUGUI[] _text = new TextMeshProUGUI[k];
            for (int i = 0; i < k; i++)
            {
                _text[i] = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                _text[i].text = j.Choice[i].ToString();
            }
            // load hint image
            hintImage.sprite = j.hintImage;
            // load question
            questionText.text = j.question;
            
        }
    }
}




