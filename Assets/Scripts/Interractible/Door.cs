using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, /*IInterractible,*/ ISwitchable
{
    private bool isClosed;

    [SerializeField] private Collider2D _door;
    [SerializeField] private Animator _anim;

    [SerializeField] private string _closedTooltip;
    [SerializeField] private string _openedTooltip;
    private string _currentTooltip;
    public string Tooltip => _currentTooltip;

    [SerializeField] private bool _isActive;
    public bool IsActive => _isActive;

    public Transform ObjectReference => transform;

    private void Start()
    {
        isClosed = true;
        _door.enabled = true;

        _currentTooltip = _closedTooltip;
    }

    public void Interract(CharacterBase user)
    {
        if (!IsActive)
            return;

        if (isClosed)
            Open();
        else
            Close();
    }
    
    public void Open()
    {
        if (!isClosed)
            return;

        isClosed = false;
        _door.enabled = false;

        _currentTooltip = _openedTooltip;
        _anim.SetBool("Opened", true);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().doorOpen, transform.position, 1f);
    }

    public void Close()
    {
        if (isClosed)
            return;

        isClosed = true;
        _door.enabled = true;

        _currentTooltip = _closedTooltip;
        _anim.SetBool("Opened", false);
        AudioManager.Instance.PlayerSound3D(AudioManager.Instance.GetSoundBoard<InterractibleSoundBoard>().doorClose, transform.position, 1f);
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void Disable()
    {
        _isActive = false;
    }
}
