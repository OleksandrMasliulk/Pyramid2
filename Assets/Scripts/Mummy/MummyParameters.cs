using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyParameters : MonoBehaviour
{
    [Header("General")]
    public LayerMask senseLayer;
    public float losRadius;
    public float senseTickTime;

    [Header("Roam State")]
    public float roamRadius;
    public float roamMoveSpeed;

    [Header("Chase State")] 
    public float chaseMoveSpeed;  

    [Header("Break LOS State")]
    public float breakLosStateDuration;
    public float breakLOSRoamRadius;

    [Header("Sense State")]
    public float senseMoveSpeed;

    [Header("Attack State")]
    public float attackDistance;

    [Header("Stunned State")]
    public float stunDuration;
}
