using UnityEngine;

namespace GlobalScripts
{
    public class GlobalUpgrades : MonoBehaviour
    {
        public static GlobalUpgrades instance;
        public int speed = 0;
        public int power = 0;
        public int lives = 3;

        public static int _startLives = 3;
        public static int _initialSpeed = 0;
        public static int _startPower = 0;
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