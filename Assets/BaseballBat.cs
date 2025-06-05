using UnityEngine;

public class BaseballBat : MonoBehaviour
{
    public BatPickupMessage messageUI; // Référence au script d’affichage de message
    public string message = "Fais clic gauche pour frapper";
    public float messageDuration = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attack = other.GetComponent<PlayerAttack>();
            if (attack != null)
            {
                attack.HasBat = true;
                Debug.Log("Batte ramassée !");
            }

            if (messageUI != null)
            {
                messageUI.ShowMessage(message, messageDuration);
            }

            Destroy(gameObject); // Supprime la batte après ramassage
        }
    }
}