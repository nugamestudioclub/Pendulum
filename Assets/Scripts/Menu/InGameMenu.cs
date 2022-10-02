using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _inGameMenu;
    public static bool gameIsPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame ()
    {
        if(gameIsPaused)
        {
            Time.timeScale = 0f;
            _inGameMenu.SetActive(gameIsPaused);
        }
        else 
        {
            Time.timeScale = 1;
            _inGameMenu.SetActive(gameIsPaused);
        }
    }
    
    public void ResumeGame()
    {
        gameIsPaused = false;
        Time.timeScale = 1;
        _inGameMenu.SetActive(gameIsPaused);
    }
    // Start is called before the first frame update
    public static void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
