using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interractible
{
    private bool isClosed;

    [SerializeField] private Collider2D door;
    [SerializeField] private Animator anim;

    protected override void Init()
    {
        base.Init();

        isClosed = true;
        door.enabled = true;
    }

    public override void Action(PlayerController user)
    {
        if (isClosed)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    private void Open()
    {
        isClosed = false;
        door.enabled = false;
        anim.SetBool("Opened", true);
    }

    private void Close()
    {
        isClosed = true;
        door.enabled = true;
        anim.SetBool("Opened", false);
    }
}
