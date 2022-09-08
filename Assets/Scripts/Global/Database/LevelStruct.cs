using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Database
{
    [System.Serializable]
    public class LevelStruct
    {
        public string levelID;
        public Sprite hintImage;
        public string question;
        public string[] Choice;
        public string answer;

        public bool isFinished;
    }
}

