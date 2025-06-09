using UnityEngine;
using TMPro;
using System.Collections;

public class ShieldPickup : MonoBehaviour
{
    public TMP_Text messageText; // Référence au texte UI

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponent<PlayerShield>();
            if (shield != null)
            {
                shield.HasShield = true;
                Debug.Log("Bouclier ramassé !");
                StartCoroutine(ShowMessage("Fais clic droit pour te protéger", 3f));
            }

            Destroy(gameObject); // Supprime l'objet ramassé
        }
    }

    IEnumerator ShowMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        messageText.gameObject.SetActive(false);
    }
}