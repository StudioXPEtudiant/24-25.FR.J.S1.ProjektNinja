using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject pauseMenu;

    private bool isGameOver = false;
    private bool isPaused = false;

    void Start()
    {
        // Cache les menus au démarrage
        if (deathScreen != null)
            deathScreen.SetActive(false);

        if (pauseMenu != null)
            pauseMenu.SetActive(false);

        // Assure que le jeu tourne normalement
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Redémarre la scène si joueur est mort et appuie sur R
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Pause / Reprise avec Échap
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
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f;
            isGameOver = true;
        }
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
        // Pour arrêter dans l'éditeur Unity
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}