using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Trivia.Countdown
{
    public class CountdownView : MonoBehaviour
    {
        [SerializeField]
        private Slider timerSlider;
        [SerializeField]
        private TextMeshProUGUI timerText;
        public float timer = 30f;
        float _timer;
        private bool timeActive;

        private void Start()
        {
            timerSlider.maxValue = timer;
            timeActive = true;
        }

        private void Update()
        {
            if(timeActive)
                Countdown();
        }
        public void Countdown()
        {
            timer -= Time.deltaTime;
            _timer = Mathf.Round(timer);
            timerSlider.value = timer;
            timerText.text = _timer.ToString();
            if (timer <= 0)
            {
                TimesUp();
                timeActive = false;
            }
        }
        void TimesUp()
        {

        }


    }
}

