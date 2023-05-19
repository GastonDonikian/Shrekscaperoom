using UnityEngine;

namespace GlobalScripts
{
    public class GlobalUpgrades : MonoBehaviour
    {
        public static GlobalUpgrades instance;
        public float speed = GlobalUpgrades._initialSpeed;
        public int power = GlobalUpgrades._startPower;
        public int lives = GlobalUpgrades._startLives;

        public static int _startLives = 4;
        public static float _initialSpeed = 0f;
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