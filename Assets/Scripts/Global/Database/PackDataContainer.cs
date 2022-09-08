using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Database
{
    [CreateAssetMenu(menuName = "Pack")]
    public class PackDataContainer : ScriptableObject
    {
        public LevelStruct[] level;
        public int unlockCost;
        public bool isUnLocked;
        public bool isCompleted;
    }
}
