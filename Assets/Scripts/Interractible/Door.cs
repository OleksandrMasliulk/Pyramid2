using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInterractible
{
    private bool isClosed;

    [SerializeField] private Collider2D door;
    [SerializeField] private Animator anim;

    public string tooltip { get; set; }

    private void Start()
    {
        isClosed = true;
        door.enabled = true;

        tooltip = "Press E to Open";
    }

    public void Interract(PlayerController user)
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
    
    public void Interract()
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

        tooltip = "Press E to Close";
        anim.SetBool("Opened", true);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().doorOpen, transform.position, 1f);
    }

    private void Close()
    {
        isClosed = true;
        door.enabled = true;

        tooltip = "Press E to Open";
        anim.SetBool("Opened", false);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().doorClose, transform.position, 1f);
    }
}
