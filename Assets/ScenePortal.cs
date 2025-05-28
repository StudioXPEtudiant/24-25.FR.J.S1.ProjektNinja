using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // <-- Important pour TextMeshPro

public class ScenePortal : MonoBehaviour
{
    public int requiredCoins = 10;
    public TextMeshProUGUI messageText; // Référence au TMP Text
    public float messageDuration = 2f;

    private bool messageShowing = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();

            if (stats != null)
            {
                if (stats.coinCount >= requiredCoins)
                {
                    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    int nextSceneIndex = currentSceneIndex + 1;

                    if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                    {
                        SceneManager.LoadScene(nextSceneIndex);
                    }
                    else
                    {
                        Debug.Log("Dernière scène atteinte.");
                    }
                }
                else if (!messageShowing)
                {
                    StartCoroutine(ShowMessage("Il te faut " + requiredCoins + " pièces !", messageDuration));
                }
            }
        }
    }

    System.Collections.IEnumerator ShowMessage(string text, float delay)
    {
        messageShowing = true;
        if (messageText != null)
        {
            messageText.text = text;
            messageText.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(delay);
            messageText.gameObject.SetActive(false);
        }
        messageShowing = false;
    }
}