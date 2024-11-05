using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health playerHealth;
    public Image healthFill;

    void Start()
    {
        if (playerHealth != null)
        {
            // Subscribe to health change events
            playerHealth.OnHealthChanged += UpdateHealthBar;
        }
    }

    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        healthFill.fillAmount = (float)currentHealth / maxHealth;
    }

    private void OnDestroy()
    {
        // Unsubscribe when the HealthBar is destroyed to avoid memory leaks
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthBar;
        }
    }
}
