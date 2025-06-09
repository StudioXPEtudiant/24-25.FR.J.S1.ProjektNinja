using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int coinCount = 0;
    public int keyCount = 0;  // Nombre de clés

    private UIManager uiManager;
    private PlayerShield playerShield;

    void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindObjectOfType<UIManager>();
        playerShield = GetComponent<PlayerShield>();
        UpdateUI();
    }

    public void AddHealth(int amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"Vie +{amount} => {currentHealth}");
        UpdateUI();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        Debug.Log($"Pièces +{amount} => {coinCount}");
        UpdateUI();
    }

    public void RemoveCoins(int amount)
    {
        coinCount = Mathf.Max(coinCount - amount, 0);
        Debug.Log($"Pièces retirées : {amount} => {coinCount}");
        UpdateUI();
    }

    public void AddKey(int amount = 1)
    {
        keyCount += amount;
        Debug.Log($"Clés +{amount} => {keyCount}");
        UpdateUI();
    }

    public bool UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--;
            Debug.Log("Clé utilisée !");
            UpdateUI();
            return true;
        }
        else
        {
            Debug.Log("Aucune clé à utiliser !");
            return false;
        }
    }

    public void TakeDamage(int amount)
    {
        if (playerShield != null && playerShield.IsProtected())
        {
            Debug.Log("Dégâts bloqués par le bouclier !");
            return;
        }

        currentHealth = Mathf.Max(currentHealth - amount, 0);
        Debug.Log($"Dégâts subis : {amount} => {currentHealth}");

        UpdateUI();

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
            gm.ShowDeathScreen();
    }

    public void UpdateUI()
    {
        if (uiManager != null)
        {
            uiManager.UpdateHealth(currentHealth);
            uiManager.UpdateCoins(coinCount);
            uiManager.UpdateKeyDisplay(keyCount);
        }
    }
}