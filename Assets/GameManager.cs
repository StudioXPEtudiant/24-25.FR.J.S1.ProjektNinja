using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject deathScreen;
    public GameObject pauseMenu;

    public bool hasBaseballBat = false;

    private bool isGameOver = false;
    private bool isPaused = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        HideMenus();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (!isGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ShowDeathScreen()
    {
        if (deathScreen != null)
            deathScreen.SetActive(true);

        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void PauseGame()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitter le jeu...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        isGameOver = false;
        isPaused = false;

        HideMenus();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recharge la scène actuelle
    }

    private void HideMenus()
    {
        if (deathScreen != null)
            deathScreen.SetActive(false);
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }
}