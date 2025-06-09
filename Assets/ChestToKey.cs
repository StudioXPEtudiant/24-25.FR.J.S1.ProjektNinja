using UnityEngine;
using TMPro;
using System.Collections;

public class ChestToKey : MonoBehaviour
{
    public int coinCost = 10;
    public GameObject keyPrefab;
    public Transform spawnPoint;
    public TMP_Text messageText; // Référence au texte UI

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            TryOpenChest();
        }
    }

    void TryOpenChest()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats stats = player.GetComponent<PlayerStats>();

        if (stats != null && stats.coinCount >= coinCost)
        {
            stats.coinCount -= coinCost;
            stats.UpdateUI();

            Debug.Log("Coffre ouvert, clé générée !");
            Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            int missing = coinCost - stats.coinCount;
            string message = "Il te faut " + coinCost + " pièces !";
            StartCoroutine(ShowMessage(message, 2f));
        }
    }

    IEnumerator ShowMessage(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        messageText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}