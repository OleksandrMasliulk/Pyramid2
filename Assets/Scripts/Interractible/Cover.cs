using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Cover : MonoBehaviour, IInterractible
{
    [SerializeField] private Transform respawnPos;
    [SerializeField] private Animator graphics;
    [SerializeField] private AssetReference dustPS;

    private PlayerDrivenCharacter _palyerHidingIn;

    [SerializeField] private string _coverTooltip;
    [SerializeField] private string _uncoverTooltip;
    private string _currentTooltip;
    public string Tooltip => _currentTooltip;

    public Transform ObjectReference => transform;

    private void Start()
    {
        _currentTooltip = _coverTooltip;
    }

    private void CoverIn(PlayerDrivenCharacter user)
    {
        _palyerHidingIn = user;

        user.transform.position = transform.position;
        user.CoverHandler.Cover();

        _currentTooltip = _uncoverTooltip;
        if (graphics != null)
            graphics.SetBool("isOpened", false);
    }

    private void Uncover(PlayerDrivenCharacter user)
    {
        _palyerHidingIn = null;

        user.transform.position = respawnPos.position;
        user.CoverHandler.Uncover();

        _currentTooltip = _coverTooltip;
        //Instantiate(dustPS, respawnPos.position, Quaternion.identity);

        if (graphics != null)
            graphics.SetBool("isOpened", true);
    }

    public void Interract(CharacterBase user)
    {
        if (user is PlayerDrivenCharacter player)
            if (_palyerHidingIn == null)
                CoverIn(player);
            else
                if (player == _palyerHidingIn)
                    Uncover(player);
                else
                    return;

    }
}
