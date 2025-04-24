using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)

    {
        currentHealth -= amount;
        Debug.Log("Le joueur prend " + amount + " dégâts. Santé restante : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        // Ajoute ici la logique pour la mort du joueur (réapparition, écran de game over, etc.)
    }
}