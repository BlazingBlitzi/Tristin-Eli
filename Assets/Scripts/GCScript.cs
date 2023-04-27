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
    public TMP_Text healthText1;
    public Image healthMeter1;

    public Image healthMeter2;
    public TMP_Text healthText2;

    public Image ButtonUI;

    //public Image[] bulletImages;
    //public Image[] bulletImages2;
    //PlayerScript pS1;
    //PlayerScript pS2;

    private GameObject Player;
    private GameObject Player2;

    float p1health;
    float p1maximumHealth = 100;
    float p2health;
    float p2maximumHealth = 100;
    float lerpSpeed;

    private void Start()
    {
        Player = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player(Clone)");
        //pS1 = Player.GetComponent<PlayerScript>();
        //pS2 = Player.GetComponent<PlayerScript>();

        lerpSpeed = (3f * Time.deltaTime);
        p1health = p1maximumHealth;
        p2health= p2maximumHealth;

    }
    
    private void Update()
    {
        healthText1.text = "Health: " + p1health + "%";
        healthText2.text = "Health: " + p2health + "%";

        

        HealthMeterLevel();
        ColorChanger();

        if (p1health >= p1maximumHealth)
        {
            p1health = p1maximumHealth;
        }
        if (p2health >= p2maximumHealth)
        { 
            p2health = p2maximumHealth;
        }
        if (p1health <= 0)
        {

        }
        if (p2health <= 0 )
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
        healthMeter1.fillAmount = Mathf.Lerp(healthMeter1.fillAmount, p1health/p1maximumHealth, lerpSpeed);
        healthMeter2.fillAmount = Mathf.Lerp(healthMeter2.fillAmount, p2health/p2maximumHealth, lerpSpeed);
    }
    /// <summary>
    /// Lerp is here too. This will just go from color A to color B at rate C 
    /// (in this case, C, the Lerp value, is just the change in health.
    /// </summary>
    void ColorChanger()
    {
        Color healthMeterColor1 = Color.Lerp(Color.red, Color.green, (p1health / p1maximumHealth));
        Color healthMeterColor2 = Color.Lerp(Color.red, Color.green, (p2health / p2maximumHealth));
        healthMeter1.color = healthMeterColor1;
        healthMeter2.color = healthMeterColor2;
    }

    public void p1Damage(float damageAmount)
    {
        if (p1health > 0)
        {
            p1health -= damageAmount;
        }
    }
    public void p2Damage(float damageAmount)
    {
        if (p2health > 0) 
        { 
            p2health -= damageAmount;
        }
    }
}
