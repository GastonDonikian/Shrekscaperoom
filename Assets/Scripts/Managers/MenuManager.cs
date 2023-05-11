using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum UnityScenes
{
    [Description("Main Menu")]
    Menu,
    [Description("Level1")]
    Level1,
    [Description("EndGame")]
    EndGame,
        
}
namespace Managers
{
    public class MenuManager : MonoBehaviour
    {
        public void LoadLevelOne() => SceneManager.LoadScene(UnityScenes.Level1.ToString());

        public void Quit() => Application.Quit();
    }
}