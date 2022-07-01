using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void OnStateEnter(PlayerController player);
    public abstract void OnStateExit(PlayerController player);
    public abstract void OnDirectionInput(PlayerController player, Vector2 direction);
    public abstract void OnInterractInput(PlayerController player);
    public abstract void OnInventoryUsePressInput(PlayerController player);
    public abstract void OnInventoryUseReleaseInput(PlayerController player);
    public abstract void OnInventoryDropInput(PlayerController player);
}
