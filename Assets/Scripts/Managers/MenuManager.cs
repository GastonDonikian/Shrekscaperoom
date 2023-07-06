using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UnityScenes
{
    [Description("MainMenu")]
    MainMenu,
    [Description("LoadLevel1Async")]
    LoadLevel1Async,
    [Description("LoadLevel2Async")]
    LoadLevel2Async,
    [Description("LoadLevel3Async")]
    LoadLevel3Async,
    [Description("Level1")]
    Level1,
    [Description("Level2")]
    Level2,
    [Description("Level3")]
    Level3,
    [Description("UpgradeDeath")]
    UpgradeDeath,
    [Description("EndGame")]
    EndGame,
        
}
namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public void LoadLevelOne() => SceneManager.LoadScene(UnityScenes.LoadLevel1Async.ToString());
        
        public void LoadLevelTwo() => SceneManager.LoadScene(UnityScenes.LoadLevel2Async.ToString());
        
        public void LoadLevelThree() => SceneManager.LoadScene(UnityScenes.LoadLevel3Async.ToString());

        public void Quit() => Application.Quit();
    }
} 