using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private PlayerParameters parameters;
    private PlayerHUDController hud;

    private int health;
    private int sanity;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        hud = GetComponent<PlayerHUDController>();

        health = parameters.maxHealth;
        sanity = parameters.maxSanity;

        hud.UpdateSanitySlider(sanity);
    }

    public void UpdateSanity(int value)
    {
        sanity += value;
        if (sanity > parameters.maxSanity)
        {
            sanity = parameters.maxSanity;
        }
        
        if (sanity < 0)
        {
            sanity = 0;
        }

        hud.UpdateSanitySlider(sanity);
    }
}
