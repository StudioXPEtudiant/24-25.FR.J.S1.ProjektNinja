using System.Collections;
using UnityEngine;
using TMPro;

public class BatPickupMessage : MonoBehaviour
{
    public TextMeshProUGUI messageText;

    public void ShowMessage(string message, float duration)
    {
        StartCoroutine(ShowMessageCoroutine(message, duration));
    }

    IEnumerator ShowMessageCoroutine(string message, float duration)
    {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        messageText.gameObject.SetActive(false);
    }
}