using System;
using UnityEngine;

namespace GlobalScripts
{
    public class GlobalVictory : MonoBehaviour
    {
        public static GlobalVictory instance;
        public bool IsVictory;
        private void Awake()
        {
            if(instance == null)
                instance = this;
            else
                Destroy(this.gameObject);
            DontDestroyOnLoad(this.gameObject);
        }
    }
}