using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public int attackDamage = 10;
    public Transform player;
    private bool canAttack = true;

    private void Update()
    {
        if (player != null && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            if (canAttack)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        canAttack = false;
        Debug.Log("L'ennemi attaque !");

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}