using UnityEngine;

public class QuitGameButton : MonoBehaviour
{
    // Appelé par le bouton via l'inspecteur
    public void QuitGame()
    {
        // Quitte le jeu (fonctionne uniquement dans le build, pas dans l'éditeur)
        Application.Quit();

        // Message pour confirmer que la fonction est bien appelée dans l'éditeur
        Debug.Log("QuitGame() a été appelé. Le jeu se fermera dans le build.");
    }
}