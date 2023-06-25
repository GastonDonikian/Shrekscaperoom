using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UnityScenes
{
    [Description("MainMenu")]
    MainMenu,
    [Description("LoadLevelAsync")]
    LoadLevelAsync,
    [Description("Level1")]
    Level1,
    [Description("UpgradeDeath")]
    UpgradeDeath,
    [Description("EndGame")]
    EndGame,
        
}
namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public void LoadLevelOne() => SceneManager.LoadScene(UnityScenes.LoadLevelAsync.ToString());

        public void Quit() => Application.Quit();
    }
} 