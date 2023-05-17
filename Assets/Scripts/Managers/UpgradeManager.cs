using GlobalScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class UpgradeManager: MonoBehaviour
    {

        public void ActionUpgradeSpeed()
        {
            GlobalUpgrades.instance.speed += 1;
            GlobalUpgrades.instance.lives -= 1;
            SceneManager.LoadScene(UnityScenes.Level1.ToString());
        }
        
        public void ActionUpgradePower()
        {
            GlobalUpgrades.instance.power += 1;
            GlobalUpgrades.instance.lives -= 1;
            SceneManager.LoadScene(UnityScenes.Level1.ToString());
        }
    }
}