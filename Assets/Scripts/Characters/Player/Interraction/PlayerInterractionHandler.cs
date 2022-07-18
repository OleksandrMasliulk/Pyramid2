using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterractionHandler : MonoBehaviour
{
    private PlayerDrivenCharacter _character;
    [SerializeField] private InterractibleSeeker _seeker;

    private IActionsInput _inputHandler;

    private void Awake()
    {
        _character = GetComponent<PlayerDrivenCharacter>();
    }

    public void Init(IActionsInput inputHandler)
    {
        _inputHandler = inputHandler;
        _inputHandler.OnInterract += Interract;
    }

    public void Interract()
    {
        if (_seeker.ObjectsSeeked.Count <= 0)
            return;

        _seeker.ObjectsSeeked[_seeker.ObjectsSeeked.Count - 1].Interract(_character);
    }

    private void OnLost()
    {
        _character.HUDHandler.Tooltip.Hide();
       Debug.Log("Interractible Lost");
    }

    private void OnSeeked()
    {
        _character.HUDHandler.Tooltip.ShowTooltip(_seeker.ObjectsSeeked[_seeker.ObjectsSeeked.Count - 1].Tooltip);
        Debug.Log("Interractible Seeked");
    }


    private void OnEnable()
    {
        _seeker.OnSeeked += OnSeeked;
        _seeker.OnLost += OnLost;
    }

    private void OnDisable()
    {
        _inputHandler.OnInterract -= Interract;

        _seeker.OnSeeked -= OnSeeked;
        _seeker.OnLost -= OnLost;
    }
}
