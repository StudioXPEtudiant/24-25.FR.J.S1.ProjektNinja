using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI messageText; // 👈 Nouveau champ pour les messages

    private Coroutine messageCoroutine;

    public void UpdateHealth(int currentHealth)
    {
        healthText.text = "Vies : " + currentHealth;
    }

    public void UpdateCoins(int coins)
    {
        coinsText.text = "Pièces : " + coins;
    }

    public void UpdateKeyDisplay(int keyCount)
    {
        if (keyText == null)
        {
            Debug.LogWarning("keyText n'est pas assigné dans UIManager !");
            return;
        }

        keyText.text = keyCount > 0 ? "Clés : " + keyCount : "";
    }

    // 👇 Nouveau : message temporaire à l'écran
    public void ShowMessage(string message, float duration)
    {
        if (messageCoroutine != null)
            StopCoroutine(messageCoroutine);

        messageCoroutine = StartCoroutine(DisplayMessage(message, duration));
    }

    private IEnumerator DisplayMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        messageText.gameObject.SetActive(false);
    }
}