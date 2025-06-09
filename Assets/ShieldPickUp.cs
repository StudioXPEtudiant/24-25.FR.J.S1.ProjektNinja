using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [SerializeField] private string pickupMessage = "Fais clic droit pour te protéger";
    [SerializeField] private float messageDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponent<PlayerShield>();
            if (shield != null)
            {
                shield.HasShield = true;
                Debug.Log("Bouclier ramassé !");

                // ✅ Appel au UIManager
                UIManager ui = FindObjectOfType<UIManager>();
                if (ui != null)
                {
                    ui.ShowMessage(pickupMessage, messageDuration);
                }
            }

            Destroy(gameObject);
        }
    }
}