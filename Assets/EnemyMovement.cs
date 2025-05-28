using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float chaseRange = 10f;
    public Transform target;

    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Mémorise le point de départ
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            if (distanceToTarget <= chaseRange)
            {
                ChasePlayer();
            }
            else
            {
                ReturnToStart();
            }
        }
        else
        {
            ReturnToStart();
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        direction.y = 0;

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(lookRotation);
        }
    }

    void ReturnToStart()
    {
        Vector3 direction = (startPosition - transform.position);

        // Si très proche de la position d’origine, ne pas bouger
        if (direction.magnitude < 0.1f) return;

        direction = direction.normalized;
        direction.y = 0;

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(lookRotation);
        }
    }
}