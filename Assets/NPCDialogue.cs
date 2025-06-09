using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    [Header("Dialogues")]
    public string[] dialogues;

    private int dialogueIndex = 0;

    [Header("UI Elements")]
    public GameObject dialogueUI;            // L’UI qui contient le texte (panel + texte)
    public TextMeshProUGUI dialogueText;    // Le composant TextMeshProUGUI pour afficher le texte

    [Header("Player Detection")]
    public Transform player;                 // Le transform du joueur
    public float talkDistance = 3f;         

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player Transform non assigné dans " + gameObject.name);
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= talkDistance)
        {
            // Si on est proche et que le joueur appuie sur E
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowDialogue();
            }
        }
        else
        {
            // Si on s’éloigne, on cache l’UI et on remet le dialogue à zéro
            if (dialogueUI.activeSelf)
            {
                dialogueUI.SetActive(false);
                dialogueIndex = 0;
            }
        }
    }

    void ShowDialogue()
    {
        if (dialogues == null || dialogues.Length == 0)
        {
            Debug.LogWarning("Pas de dialogues assignés dans " + gameObject.name);
            return;
        }

        dialogueUI.SetActive(true);

        dialogueText.text = dialogues[dialogueIndex];

        dialogueIndex++;

        if (dialogueIndex >= dialogues.Length)
        {
            dialogueIndex = 0;  // Recommence à zéro si fin du tableau
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, talkDistance);
    }
}