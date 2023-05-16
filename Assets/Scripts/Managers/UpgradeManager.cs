using GlobalScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class UpgradeManager: MonoBehaviour
    {
        private GlobalUpgrades _globalUpgrades;
        private void Start()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            this._globalUpgrades = GlobalUpgrades.instance;
        }

        public void ActionUpgradeSpeed()
        {
            _globalUpgrades.IncreaseSpeed();
            SceneManager.LoadScene(UnityScenes.Level1.ToString());
        }
        
        public void ActionUpgradePower()
        {
            _globalUpgrades.IncreasePower();
            SceneManager.LoadScene(UnityScenes.Level1.ToString());
        }
    }
}