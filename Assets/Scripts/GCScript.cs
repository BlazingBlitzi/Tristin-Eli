/*****************************************************************************
// File Name :         Fragile Wall
// Author :            Elijah Vroman
// Creation Date :     4/12/23
// Brief Description : This is the Game Controller, which was mostly created 
to keep track of UI elements and health.It possesses functions that other 
scripts will be calling to change those elements.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Security.Cryptography;

public class GCScript : MonoBehaviour
{
    public TMP_Text HealthText1;
    public Image HealthMeter1;

    public Image HealthMeter2;
    public TMP_Text HealthText2;

    public TMP_Text AmmoCounterP1;
    public TMP_Text AmmoCounterP2;

    public GameObject ButtonUI;


    //public Image[] bulletImages;
    //public Image[] bulletImages2;
    PlayerScript PS1;
    PlayerScript PS2;

    private GameObject player1;
    private GameObject player2;

    public float P1health;
    public float P1maximumHealth = 100;
    public float P2health;
    public float P2maximumHealth = 100;
    public float LerpSpeed;

    void Start()
    {
        LerpSpeed = (3f * Time.deltaTime);
        P1health = P1maximumHealth;
        P2health= P2maximumHealth;
    }
    
    /// <summary>
    /// Firstly, Update is constantly finding the player to check how much ammo
    /// needs to be displayed. Similarly, the health is also being found AND 
    /// updated, and of course if health is 0 the scene will reload. Both 
    /// ColorChanger and HealthMeter functions are constantly called so the UI
    /// can always be up to date.
    /// </summary>
    private void Update()
    {
        if (GameObject.Find("Player1") != null)
        {
            player1 = GameObject.Find("Player1");
            PS1 = player1.GetComponent<PlayerScript>();

            AmmoCounterP1.text = "Ammo: " + PS1.ammoCount;
            if (PS1.ammoCount <= 0)
            {
                AmmoCounterP1.text = "Reloading!";
            }
        }
        if (GameObject.Find("Player(Clone)") != null)
        {
            if (GameObject.Find("Player1") == null)
            {
                player2.name = "Player1";
            }
            player2 = GameObject.Find("Player(Clone)");
            PS2 = player2.GetComponent<PlayerScript>();
            AmmoCounterP2.text = "Ammo: " + PS2.ammoCount;
            if (PS2.ammoCount <= 0)
            {
                AmmoCounterP2.text = "Reloading!";
            }

        }

        HealthText1.text = "Health: " + P1health + "%";
        HealthText2.text = "Health: " + P2health + "%";

        HealthMeterLevel();
        ColorChanger();


        if (P1health >= P1maximumHealth)
        {
            P1health = P1maximumHealth;
        }
        if (P2health >= P2maximumHealth)
        { 
            P2health = P2maximumHealth;
        }
        if (P1health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (P2health <= 0 )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        HealthMeter1.fillAmount = Mathf.Lerp(HealthMeter1.fillAmount, P1health/P1maximumHealth, LerpSpeed);
        HealthMeter2.fillAmount = Mathf.Lerp(HealthMeter2.fillAmount, P2health/P2maximumHealth, LerpSpeed);
    }
    /// <summary>
    /// Lerp is here too. This will just go from color A to color B at rate C 
    /// (in this case, C, the Lerp value, is just the change in health.
    /// </summary>
    void ColorChanger()
    {
        Color healthMeterColor1 = Color.Lerp(Color.red, Color.green, (P1health / P1maximumHealth));
        Color healthMeterColor2 = Color.Lerp(Color.red, Color.green, (P2health / P2maximumHealth));
        HealthMeter1.color = healthMeterColor1;
        HealthMeter2.color = healthMeterColor2;
    }
    public void p1Damage(float damageAmount)
    {
        if (P1health > 0)
        {
            P1health -= damageAmount;
        }
    }
    public void p2Damage(float damageAmount)
    {
        if (P2health > 0) 
        { 
            P2health -= damageAmount;
        }
    }
}
