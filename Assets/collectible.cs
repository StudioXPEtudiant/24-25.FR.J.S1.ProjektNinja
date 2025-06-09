using UnityEngine;

public class Collectible : MonoBehaviour
{
    public enum CollectibleType { Health, Coins, Key }
    public CollectibleType type;
    public int value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats stats = other.GetComponent<PlayerStats>();
            if (stats != null)
            {
                switch (type)
                {
                    case CollectibleType.Health:
                        stats.AddHealth(value);
                        break;
                    case CollectibleType.Coins:
                        stats.AddCoins(value);
                        break;
                    case CollectibleType.Key:
                        stats.AddKey(value); // Utilise AddKey pour gérer les clés
                        Debug.Log("Clé(s) ramassée(s) !");
                        break;
                }

                Destroy(gameObject);
            }
        }
    }
}