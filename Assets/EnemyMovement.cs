using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public Transform target; // Assigne le joueur ici dans l'inspecteur

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
}