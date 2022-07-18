using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInterractible
{
    private bool isClosed;

    [SerializeField] private Collider2D door;
    [SerializeField] private Animator anim;

    [SerializeField] private string _closedTooltip;
    [SerializeField] private string _openedTooltip;
    private string _currentTooltip;
    public string Tooltip => _currentTooltip;

    private void Start()
    {
        isClosed = true;
        door.enabled = true;

        _currentTooltip = _closedTooltip;
    }

    public void Interract(CharacterBase user)
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

        _currentTooltip = _openedTooltip;
        anim.SetBool("Opened", true);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().doorOpen, transform.position, 1f);
    }

    private void Close()
    {
        isClosed = true;
        door.enabled = true;

        _currentTooltip = _closedTooltip;
        anim.SetBool("Opened", false);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().doorClose, transform.position, 1f);
    }
}
