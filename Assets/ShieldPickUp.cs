using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponent<PlayerShield>();
            if (shield != null)
            {
                shield.HasShield = true;
                Debug.Log("Bouclier ramassé !");
            }

            Destroy(gameObject); // Supprime l'objet ramassé
        }
    }
}