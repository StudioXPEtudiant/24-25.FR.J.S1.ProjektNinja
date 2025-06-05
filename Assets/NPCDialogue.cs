using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogues;
    private int dialogueIndex = 0;

    public GameObject dialogueUI;
    public TextMeshProUGUI dialogueText;

    public Transform player;
    public float talkDistance = 3f;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= talkDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowDialogue();
            }
        }
        else
        {
            if (dialogueUI.activeSelf)
            {
                dialogueUI.SetActive(false);
                dialogueIndex = 0; // On recommence le dialogue si le joueur s’éloigne
            }
        }
    }

    void ShowDialogue()
    {
        if (dialogues == null || dialogues.Length == 0) return;

        dialogueUI.SetActive(true);
        dialogueText.text = dialogues[dialogueIndex];

        dialogueIndex = (dialogueIndex + 1) % dialogues.Length;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, talkDistance);
    }
}