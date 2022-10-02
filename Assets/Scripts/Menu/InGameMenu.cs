using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    private GameObject _camera;
    [SerializeField] private GameObject inGameMenu;
    public bool gameisPaused;
    public AudioSource[] audios;

    private void Awake()
    {
        if (Camera.main != null) _camera = Camera.main.gameObject;
        audios = FindObjectsOfType<AudioSource>();
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
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].Pause();
            }
            inGameMenu.SetActive(gameisPaused);
            _camera.GetComponent<Navigation>().enabled = false;
        }
        else 
        {
            Time.timeScale = 1;
            for (int i = 0; i < audios.Length; i++)
            {
                audios[i].Play();
            }
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
        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].Play();
        }
    }
    // Start is called before the first frame update
    public static void BackToMenu()
    {
        SceneManager.LoadScene("Menu",LoadSceneMode.Single);
    }
}
