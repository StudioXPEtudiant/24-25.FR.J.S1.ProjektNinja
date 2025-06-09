using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool HasShield = false;
    public bool IsShieldActive = false;

    private float shieldDuration = 2f;       // Durée max de blocage
    private float shieldCooldown = 1f;       // Temps d’attente après avoir bloqué
    private float shieldTimer = 0f;
    private bool isOnCooldown = false;

    void Update()
    {
        if (!HasShield) return;

        if (Input.GetMouseButtonDown(1) && !IsShieldActive && !isOnCooldown)
        {
            ActivateShield();
        }

        if (IsShieldActive)
        {
            shieldTimer += Time.deltaTime;

            if (Input.GetMouseButtonUp(1) || shieldTimer >= shieldDuration)
            {
                DeactivateShield();
            }
        }
    }

    void ActivateShield()
    {
        IsShieldActive = true;
        shieldTimer = 0f;
        Debug.Log("Bouclier activé !");
    }

    void DeactivateShield()
    {
        if (IsShieldActive)
        {
            IsShieldActive = false;
            isOnCooldown = true;
            Debug.Log("Bouclier désactivé.");
            Invoke(nameof(ResetCooldown), shieldCooldown);
        }
    }

    void ResetCooldown()
    {
        isOnCooldown = false;
    }

    public bool IsProtected()
    {
        return HasShield && IsShieldActive;
    }
}