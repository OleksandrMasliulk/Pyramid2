using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerParameters : MonoBehaviour
{
    //public delegate float IntiPlayer();
    public UnityEvent InitPlayerEvent;

    public float movementSpeed { get; private set; }

    public int maxSanity { get; private set; }

    public bool isAlive { get; private set; }
    public bool isCovered { get; private set; }

    private void Awake()
    {
        InitPlayerEvent?.Invoke();
    }

    public void SetMovementSpeed(float _speed)
    {
        movementSpeed = _speed;
    }

    public void SetMaxSanity(int _maxSanity)
    {
        maxSanity = _maxSanity;
    }

    public void SetIsAlive(bool _isAlive)
    {
        isAlive = _isAlive;
    }

    public void SetIsCovered(bool value)
    {
        isCovered = value;
    }
}
