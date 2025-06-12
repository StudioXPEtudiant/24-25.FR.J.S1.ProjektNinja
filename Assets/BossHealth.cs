using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    [Header("Clé à drop")]
    public GameObject clePrefab; // Le prefab de la clé
    public Transform cleSpawnPoint; // L'endroit où la clé apparaîtra (facultatif)

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Méthode à appeler quand le boss prend des dégâts
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Faire apparaître la clé
        if (clePrefab != null)
        {
            Vector3 spawnPosition = cleSpawnPoint != null ? cleSpawnPoint.position : transform.position;
            Instantiate(clePrefab, spawnPosition, Quaternion.identity);
        }

        // Détruire le boss
        Destroy(gameObject);
    }
}