using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attack = other.GetComponent<PlayerAttack>();
            if (attack != null)
            {
                attack.HasBat = true;
                Debug.Log("Batte ramassée !");
                Destroy(gameObject); // Retire la batte de la scène
            }
        }
    }
}