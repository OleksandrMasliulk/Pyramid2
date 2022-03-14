using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerParameters : MonoBehaviour
{
    //public delegate float IntiPlayer();
    public UnityEvent InitPlayerEvent;

    public float movementSpeed { get; private set; }

    public int maxHealth { get; private set; }

    private void Start()
    {
        InitPlayerEvent?.Invoke();
    }

    public void SetMovementSpeed(float _speed)
    {
        movementSpeed = _speed;
    }

    public void SetMaxHealth(int _maxHealth)
    {
        maxHealth = _maxHealth;
    }
}
