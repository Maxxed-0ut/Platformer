using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 200f;
    public float chipSpeed = 3f;

    public Image healthBar;
    public Image healthBarBackground;
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

        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(Random.Range(5f, 10f));
        }
    }

    public void UpdateHealthUI()
    {
                Debug.Log("Updating health UI");
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        UpdateHealthUI();
    }
}
