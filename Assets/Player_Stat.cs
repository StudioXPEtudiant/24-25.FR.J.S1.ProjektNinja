using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int coinCount = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log("Vie + " + amount + " => " + currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Dégâts - " + amount + " => " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        Debug.Log("Pièces + " + amount + " => " + coinCount);
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