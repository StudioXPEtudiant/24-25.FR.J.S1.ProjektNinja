using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI keyText;

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

        if (keyCount > 0)
            keyText.text = "Clés : " + keyCount;
        else
            keyText.text = "";
    }
}