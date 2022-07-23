using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour, IInterractible
{
    [SerializeField] private Transform respawnPos;
    [SerializeField] private Animator graphics;
    [SerializeField] private GameObject dustPS;

    //private PlayerController _palyerHidingIn;

    [SerializeField] private string _coverTooltip;
    [SerializeField] private string _uncoverTooltip;
    private string _currentTooltip;
    public string Tooltip => _currentTooltip;

    public Transform ObjectReference => transform;

    private void Start()
    {
        _currentTooltip = _coverTooltip;
    }

    public void Interract(PlayerDrivenCharacter user)
    {
        //if (_palyerHidingIn == null)
        //{
        //    CoverIn(user);
        //}
        //else
        //{
        //    if (user == _palyerHidingIn)
        //    {
        //        Uncover(user);
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
    }

    private void CoverIn(PlayerDrivenCharacter user)
    {
        //_palyerHidingIn = user;

        //user.SetState(user.coveredState);
        //user.transform.position = transform.position;
        //user.CoverController.SetCover(this);

        //gameObject.layer = 10;
        _currentTooltip = _uncoverTooltip;
        //if (graphics != null)
        //    graphics.SetBool("isOpened", false);
    }

    private void Uncover(PlayerDrivenCharacter user)
    {
        //_palyerHidingIn = null;

        //user.SetState(user.aliveState);
        //user.transform.position = respawnPos.position;
        //user.CoverController.SetCover(null);

        //gameObject.layer = 12;
        _currentTooltip = _uncoverTooltip;
        //Instantiate(dustPS, respawnPos.position, Quaternion.identity);
        //if (graphics != null)
        //    graphics.SetBool("isOpened", true);
    }

    public void Interract(CharacterBase user)
    {
        
    }
}
