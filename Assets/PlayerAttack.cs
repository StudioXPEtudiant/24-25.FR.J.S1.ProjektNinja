using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool HasBat = false;
    public float attackRange = 2f;
    public int batDamage = 2;
    public LayerMask enemyLayer;

    void Start()
    {
        // Vérifie si le GameManager indique que le joueur possède la batte
        if (GameManager.Instance != null)
        {
            HasBat = GameManager.Instance.hasBaseballBat;
        }
    }

    void Update()
    {
        if (HasBat && Input.GetMouseButtonDown(0)) // Clic gauche
        {
            Attack();
        }
    }

    void Attack()
    {
        // Détection des ennemis dans la portée d'attaque
        Vector3 attackPoint = transform.position + transform.forward;
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint, attackRange, enemyLayer);

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