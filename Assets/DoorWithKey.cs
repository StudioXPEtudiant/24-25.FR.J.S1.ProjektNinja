using UnityEngine;
using TMPro;
using System.Collections;

public class DoorWithKey : MonoBehaviour
{
    public GameObject doorObject;
    public TMP_Text messageText; // Référence à un texte UI pour afficher les messages

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();
            if (stats != null && stats.UseKey())
            {
                Debug.Log("Porte déverrouillée avec la clé !");
                if (doorObject != null)
                    doorObject.SetActive(false);
            }
            else
            {
                Debug.Log("Vous avez besoin d'une clé pour ouvrir la porte.");
                StartCoroutine(ShowMessage("Il te faut 1 clé !", 2f));
            }
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