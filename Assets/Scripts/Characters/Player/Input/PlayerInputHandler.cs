using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour, IListenAxisInput, IInventoryInput, IActionsInput
{
    public float Horizontal { get; private set; }
    public float Vertical { get; private set; }

    public event Action OnSlot1;
    public event Action OnSlot2;
    public event Action OnSlot3;
    public event Action OnSlot4;
    public event Action OnDrop;
    public event Action OnUsePress;
    public event Action OnUseRelease;
    public event Action OnInterract;

    public void ReadInput()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Alpha1))
            OnSlot1?.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            OnSlot2?.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            OnSlot3?.Invoke();
        if (Input.GetKeyDown(KeyCode.Alpha4))
            OnSlot4?.Invoke();

        if (Input.GetKeyDown(KeyCode.F))
            OnUsePress?.Invoke();
        if (Input.GetKeyUp(KeyCode.F))
            OnUseRelease?.Invoke();
        if (Input.GetKeyDown(KeyCode.G))
            OnDrop?.Invoke();

        if (Input.GetKeyDown(KeyCode.E))
            OnInterract?.Invoke();
    }

    private void Update()
    {
        ReadInput();
    }
}
