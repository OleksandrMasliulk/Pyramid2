using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour, IInterractible
{
    [SerializeField] private Transform respawnPos;
    [SerializeField] private Animator graphics;
    [SerializeField] private GameObject dustPS;

    private PlayerController _palyerHidingIn;

    public string Tooltip { get; set; }

    private void Start()
    {
        Tooltip = "COVER";
    }

    public void Interract(PlayerController user)
    {
        if (_palyerHidingIn == null)
        {
            CoverIn(user);
        }
        else
        {
            if (user == _palyerHidingIn)
            {
                Uncover(user);
            }
            else
            {
                return;
            }
        }
    }

    private void CoverIn(PlayerController user)
    {
        _palyerHidingIn = user;

        user.SetState(user.coveredState);
        user.transform.position = transform.position;
        user.CoverController.SetCover(this);

        //gameObject.layer = 10;
        Tooltip = "UNCOVER";
        if (graphics != null)
            graphics.SetBool("isOpened", false);
    }

    private void Uncover(PlayerController user)
    {
        _palyerHidingIn = null;

        user.SetState(user.aliveState);
        user.transform.position = respawnPos.position;
        user.CoverController.SetCover(null);

        //gameObject.layer = 12;
        Tooltip = "COVER";
        Instantiate(dustPS, respawnPos.position, Quaternion.identity);
        if (graphics != null)
            graphics.SetBool("isOpened", true);
    }
}
