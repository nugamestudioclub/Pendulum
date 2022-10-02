using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //load the game scene
    public static void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    
    //Quit the game
    public static void QuitGame()
    {
        Application.Quit();
    }
}
