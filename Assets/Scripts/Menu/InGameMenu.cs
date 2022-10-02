using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private GameObject _camera;
    [SerializeField] private GameObject inGameMenu;
    public bool gameisPaused;

    private void Awake()
    {
        if (Camera.main != null) _camera = Camera.main.gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameisPaused = !gameisPaused;
            PauseGame();
        }
    }
    void PauseGame ()
    {
        if(gameisPaused)
        {
            Time.timeScale = 0f;
            inGameMenu.SetActive(gameisPaused);
            _camera.GetComponent<Navigation>().enabled = false;
        }
        else 
        {
            Time.timeScale = 1;
            inGameMenu.SetActive(gameisPaused);
            _camera.GetComponent<Navigation>().enabled = true;
        }
    }
    
    public void ResumeGame()
    {
        gameisPaused = false;
        Time.timeScale = 1;
        inGameMenu.SetActive(gameisPaused);
        _camera.GetComponent<Navigation>().enabled = true;
    }
    // Start is called before the first frame update
    public static void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
