using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool HasBat = false;
    public float attackRange = 2f;
    public int batDamage = 2;
    public LayerMask enemyLayer;

    [Header("Cooldown")]
    public float attackCooldown = 0.5f;
    private float cooldownTimer = 0f;

    void Start()
    {
        if (GameManager.Instance != null)
        {
            HasBat = GameManager.Instance.hasBaseballBat;
        }
    }

    void Update()
    {
        // Réduction du timer de cooldown
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;

        if (HasBat && Input.GetMouseButtonDown(0) && cooldownTimer <= 0f)
        {
            Attack();
            cooldownTimer = attackCooldown;
        }
    }

    void Attack()
    {
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