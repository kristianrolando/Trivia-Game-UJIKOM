using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Trivia.Database
{
    public class DatabaseController : MonoBehaviour
    {
        public static DatabaseController Instance;
        public PackDataContainer[] packData;
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
        //public string[] GetPackList()
        //{

        //}
        //public string[] GetLevelList(string packID)
        //{

        //}
        //public LevelStruct GetLevelData(string levelID)
        //{

        //}
    }
}


