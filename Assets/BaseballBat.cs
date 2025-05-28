using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    public string pickupMessage = "Fais clic droit pour frapper";
    [SerializeField] private float messageDuration = 2f; // Durée modifiable dans l’inspecteur

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attack = other.GetComponent<PlayerAttack>();
            if (attack != null)
            {
                attack.HasBat = true;
                Debug.Log("Batte ramassée !");

                BatPickupMessage messageUI = FindObjectOfType<BatPickupMessage>();
                if (messageUI != null)
                {
                    messageUI.ShowMessage(pickupMessage, messageDuration);
                }

                Destroy(gameObject);
            }
        }
    }
}