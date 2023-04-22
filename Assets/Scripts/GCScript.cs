using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Security.Cryptography;

public class GCScript : MonoBehaviour
{
    public TMP_Text healthText;
    public Image healthMeter;

    float health;
    float maximumHealth = 100f;
    float lerpSpeed;

    private void Start()
    {
        lerpSpeed = (3f * Time.deltaTime);
        health = maximumHealth;
    }
    private void Update()
    {
        healthText.text = "Health: " + health + "%";

        HealthMeterLevel();
        ColorChanger();

        if (health >= maximumHealth)
        {
            health = maximumHealth;
        }
        if (health <= 0)
        {

        }
    }
    /// <summary>
    /// I used this video -https://www.youtube.com/watch?v=ZzkIn41DFFo- to make
    /// this style of meter and understand Mathf.Lerp. Lerp takes 3 values, in
    /// this case the fillAmount (A), the level to fill it to (B) and a rate 
    /// (C) to fill it at.
    /// </summary>
    void HealthMeterLevel()
    {
        healthMeter.fillAmount = Mathf.Lerp(healthMeter.fillAmount, health/maximumHealth, lerpSpeed);
    }
    /// <summary>
    /// Lerp is here too. This will just go from color A to color B at rate C 
    /// (in this case, C, the Lerp value, is just the change in health.
    /// </summary>
    void ColorChanger()
    {
        Color healthMeterColor = Color.Lerp(Color.red, Color.green, (health / maximumHealth));
        healthMeter.color = healthMeterColor;
    }

    public void Damage(float damageAmount)
    {
        if (health > 0)
        {
            health -= damageAmount;
        }
    }
    public void Heal(float healAmount)
    {
        if (health < maximumHealth)
        {
            health += healAmount;
        }
    }
    
}
