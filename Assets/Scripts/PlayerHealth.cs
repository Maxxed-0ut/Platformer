using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;


public class PlayerHealth : MonoBehaviour
{
    [Header("Helath Bar")]
    private float health;
    private float lerpTimer;
    public float maxHealth = 200f;
    public float chipSpeed = 3f;

    public UnityEngine.UI.Image healthBar;
    public UnityEngine.UI.Image healthBarBackground;
    [Header("Damage Overlay")]
    public UnityEngine.UI.Image overlay;
    public float duration ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        Debug.Log("Updating health UI");
        float FillF = healthBar.fillAmount;
        float FillB = healthBarBackground.fillAmount;
        float hFraction = health / maxHealth;

        if (FillB > hFraction)
        {
            healthBar.fillAmount = hFraction;
            healthBarBackground.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = Mathf.Clamp01(percentComplete);
            healthBarBackground.fillAmount = Mathf.Lerp(FillB, hFraction, percentComplete);
        }
        
        else if (FillB < hFraction)
        {
            healthBar.fillAmount = hFraction;
            healthBarBackground.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = Mathf.Clamp01(percentComplete);
            healthBarBackground.fillAmount = Mathf.Lerp(FillB, hFraction, percentComplete);
            
        }
        else
        {
            healthBarBackground.color = Color.white;
            healthBar.fillAmount = hFraction;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        UpdateHealthUI();
    }
    public void Heal(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        UpdateHealthUI();
    }
}
