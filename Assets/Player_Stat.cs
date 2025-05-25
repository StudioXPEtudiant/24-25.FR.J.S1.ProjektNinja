using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int coinCount = 0;

    private UIManager uiManager;

    void Start()
    {
        currentHealth = maxHealth;

        uiManager = FindObjectOfType<UIManager>();
        if (uiManager != null)
        {
            uiManager.UpdateHealth(currentHealth);
            uiManager.UpdateCoins(coinCount);
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Vie + " + amount + " => " + currentHealth);

        if (uiManager != null)
            uiManager.UpdateHealth(currentHealth);
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        Debug.Log("Pièces + " + amount + " => " + coinCount);

        if (uiManager != null)
            uiManager.UpdateCoins(coinCount);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        Debug.Log("Dégâts subis : " + amount + " => " + currentHealth);

        if (uiManager != null)
            uiManager.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.ShowDeathScreen();
        }
    }
}