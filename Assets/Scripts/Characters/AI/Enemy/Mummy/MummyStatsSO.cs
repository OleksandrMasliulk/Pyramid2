using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mummy", menuName = "Characters/New Mummy")]
public class MummyStatsSO : CharacterBaseStatsSO
{
    [Header("General")]
    [SerializeField] private LayerMask _senseLayer;
    public LayerMask SenseLayer => _senseLayer;
    [SerializeField] private float _senseTickTime;
    public float SenseTickTime => _senseTickTime;
    [SerializeField]private float _lineOfSightRadius;
    public float LineOfSightRadius => _lineOfSightRadius;

    [Header("Roam State")]
    [SerializeField] private float _roamRadius;
    public float RoamRadius => _roamRadius;
    
    [Header("Chase State")]
    [SerializeField] private float _chaseSpeed;
    public float ChaseSpeed => _chaseSpeed;

    [Header("Break LOS State")]
    [SerializeField] private float _breakLosStateDuration;
    public float BreakLoSStateDuration => _breakLosStateDuration;
    [SerializeField] private float _breakLOSRoamRadius;
    public float BreakLoSRoamRadius => _breakLOSRoamRadius;

    [Header("Sense State")]
    [SerializeField] private float _senseMoveSpeed;
    public float SenseMoveSpeed => _senseMoveSpeed;

    [Header("Attack State")]
    [SerializeField] private float _attackDistance;
    public float AttackDistance => _attackDistance;

    [Header("Stunned State")]
    [SerializeField] private float _stunDuration;
    public float StunDuration => _stunDuration;
}
