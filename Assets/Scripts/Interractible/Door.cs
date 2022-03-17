using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interractible
{
    private bool isClosed;

    [SerializeField] private Collider2D door;

    protected override void Init()
    {
        base.Init();

        isClosed = true;
        door.enabled = true;
    }

    protected override void Action()
    {
        if (isClosed)
        {
            Open();
        }
        else
        {
            Close();
        }

        Debug.Log("Closed: " + isClosed);
    }

    private void Open()
    {
        isClosed = false;
        door.enabled = false;
    }

    private void Close()
    {
        isClosed = true;
        door.enabled = true;
    }
}
