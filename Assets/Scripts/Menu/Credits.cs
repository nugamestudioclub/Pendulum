using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public static void BackToMenu()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
    public static void QuitGame()
    {
        Application.Quit();
    }
}
