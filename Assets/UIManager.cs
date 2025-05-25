using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;

    public void UpdateHealth(int currentHealth)
    {
        healthText.text = "Vies : " + currentHealth;
    }

    public void UpdateCoins(int coins)
    {
        coinsText.text = "Pièces : " + coins;
    }
}