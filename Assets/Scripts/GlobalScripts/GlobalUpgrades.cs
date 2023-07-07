using UnityEngine;

namespace GlobalScripts
{
    public class GlobalUpgrades : MonoBehaviour
    {
        public static GlobalUpgrades instance;
        public int speed = GlobalUpgrades._initialSpeed;
        public int power = GlobalUpgrades._startPower;
        public int lives = GlobalUpgrades._startLives;
        public float volume = 2;
        public  Color brightness = new Color(0,0,0,0);

        public static int _startLives = 4;
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