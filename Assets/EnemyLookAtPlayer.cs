using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    public Transform player; // Glisse ici le GameObject du joueur

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.y = 0f; // Pour éviter que l’ennemi regarde vers le haut ou le bas

            if (direction != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
            }
        }
    }
}