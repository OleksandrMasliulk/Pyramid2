using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerDrivenCharacter))]
public class PlayerCoverController : MonoBehaviour
{
    public delegate void OnPlayerCoveredDelegate();
    public event OnPlayerCoveredDelegate OnPlayerCovered;

    private Cover _coverHidingIn;
    public Cover Cover => _coverHidingIn;

    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void SetCover(Cover cover)
    {
        _coverHidingIn = cover;

        if (cover == null)
        {
            col.isTrigger = false;
        }
        else
        {
            col.isTrigger = true;
        }
    }
}
