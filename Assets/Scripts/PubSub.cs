using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;

namespace Trivia.PubSub
{
    public class PubSub { }

    public struct AnswerClick
    {
        public string answer;
        public AnswerClick(string answer)
        {
            this.answer = answer;
        }
    }
    public struct FinishLevel
    {
        public string levelID;
        public FinishLevel(string levelID)
        {
            this.levelID = levelID;
        }
    }
    public struct FinishAllLevel { }
}
