using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //load the game scene
    public static void StartGame()
    {
        SceneManager.LoadScene("Main");
    }
    
    //Quit the game
    public static void QuitGame()
    {
        Application.Quit();
    }
}
