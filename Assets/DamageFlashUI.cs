using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    public Image damageOverlay;
    public float flashDuration = 0.3f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.4f);

    private float flashTimer = 0f;

    void Start()
    {
        if (damageOverlay == null)
        {
            Debug.LogError("DamageOverlay n'est pas assigné dans DamageFlash !");
        }
        else
        {
            // On commence avec l'image totalement transparente
            damageOverlay.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0f);
        }
    }

    void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            // Calcul alpha qui décroît pour un effet de fondu
            float alpha = Mathf.Lerp(0f, flashColor.a, flashTimer / flashDuration);
            damageOverlay.color = new Color(flashColor.r, flashColor.g, flashColor.b, alpha);

            if (flashTimer <= 0)
            {
                // Fin du flash : alpha à 0
                damageOverlay.color = new Color(flashColor.r, flashColor.g, flashColor.b, 0f);
            }
        }
    }

    public void TakeDamage()
    {
        flashTimer = flashDuration;
        // On met le alpha à la valeur max au début du flash
        damageOverlay.color = new Color(flashColor.r, flashColor.g, flashColor.b, flashColor.a);
    }
}