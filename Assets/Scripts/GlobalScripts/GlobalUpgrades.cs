using UnityEngine;

namespace GlobalScripts
{
    public class GlobalUpgrades : MonoBehaviour
    {
        public static GlobalUpgrades instance;
        private int speed;
        private int power;
        private int lives;

        private int _startSpeed = 3;
        private int _startPower = 1;
        private int _startLives = 3;

        private int _powerLimit = 5;
        private int _speedLimit = 5;
        private void Awake()
        {
            if(instance != null)
                Destroy(this.gameObject);
            instance = this;
            this.speed = _startSpeed;
            this.power = _startPower;
            this.lives = _startLives;
            DontDestroyOnLoad(this.gameObject);
        }
        
        public int GetSpeed()
        {
            return speed;
        }
        public int GetPower()
        {
            return power;
        }

        public int DecreaseLife()
        {
            lives -= 1;
            return lives;
        }

        public int IncreaseSpeed()
        {
            if (speed < _speedLimit)
                speed += 1;
            return speed;
        }

        public int IncreasePower()
        {
            if (power < _powerLimit) 
                power += 1;
            return power;
        }
    }
}