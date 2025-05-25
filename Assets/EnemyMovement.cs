using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float chaseRange = 10f; // distance maximale de poursuite
    public Transform target;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Ne poursuit que si le joueur est à portée
            if (distanceToTarget <= chaseRange)
            {
                // Direction du mouvement
                Vector3 direction = (target.position - transform.position).normalized;
                direction.y = 0; // Ne pas bouger en hauteur

                // Déplacement
                rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

                // Rotation : tourner vers la direction du joueur
                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    rb.MoveRotation(lookRotation);
                }
            }
        }
    }
}