using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Ennemi a pris " + amount + " dégâts. Vie restante : " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("L'ennemi est mort !");
        Destroy(gameObject);
    }
}