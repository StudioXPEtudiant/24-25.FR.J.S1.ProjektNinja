using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool HasShield = false;
    public bool IsShieldActive = false;

    void Update()
    {
        if (HasShield)
        {
            if (Input.GetMouseButtonDown(1)) // clic droit
            {
                ActivateShield();
            }
            else if (Input.GetMouseButtonUp(1))
            {
                DeactivateShield();
            }
        }
    }

    void ActivateShield()
    {
        IsShieldActive = true;
        Debug.Log("Bouclier activé !");
        // Tu peux aussi activer un objet visuel ici si tu veux
    }

    void DeactivateShield()
    {
        IsShieldActive = false;
        Debug.Log("Bouclier désactivé.");
    }

    public bool IsProtected()
    {
        return HasShield && IsShieldActive;
    }
}