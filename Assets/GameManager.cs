using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreen;

    public void ShowDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f; // Met le jeu en pause
        }
    }
}