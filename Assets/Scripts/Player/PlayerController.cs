using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageable
{
    public static PlayerController Instance { get; private set; }

    private PlayerParameters parameters;
    private PlayerGraphicsController graphics;
    private PlayerHUDController hud;

    private int health;
    private int sanity;

    public delegate void OnLowSanityDelegate();
    public event OnLowSanityDelegate OnLowSanity;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        graphics = GetComponent<PlayerGraphicsController>();
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
        else if (sanity <= 25)
        {
            OnLowSanity?.Invoke();
        }

        hud.UpdateSanitySlider(sanity);
    }

    public void TakeDamage(int damage)
    {
        Die();
    }

    private void Die()
    {
        Debug.LogWarning("!!! PLAYER DIED !!!");

        parameters.SetIsAlive(false);
        graphics.SetDie();

        hud.HideHUD();

        GameController.Instance.Lose();
    }

    public int GetSanity()
    {
        return sanity;
    }

    public bool GetIsAlive()
    {
        return parameters.isAlive;
    }
}
