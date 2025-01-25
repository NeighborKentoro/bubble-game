using UnityEngine;

public class MenuController : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    

    public void StartGame()
    {
        EventManager.StartGame();
    }

    public void ExitGame()
    {
        #if UNITY_STANDALONE
                //Quit the application
                Application.Quit();
        #endif

        #if UNITY_EDITOR
                //Stop playing the scene
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
