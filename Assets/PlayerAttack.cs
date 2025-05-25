using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool HasBat = false;
    public float attackRange = 2f;
    public int batDamage = 2;
    public LayerMask enemyLayer;

    void Update()
    {
        if (HasBat && Input.GetMouseButtonDown(0)) // Clic gauche
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position + transform.forward, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(batDamage);
            }
        }

        Debug.Log("Attaque !");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, attackRange);
    }
}