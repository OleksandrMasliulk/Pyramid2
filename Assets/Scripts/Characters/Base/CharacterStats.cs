using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats
{
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed => _moveSpeed;

    public bool IsAlive { get; set; }
}
