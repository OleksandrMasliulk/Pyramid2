using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour, IInterractible
{
    [SerializeField] private Transform respawnPos;
    [SerializeField] private Animator graphics;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to Cover";
    }

    public void Interract(PlayerController user)
    {
        if (user.GetPlayerParameters().isCovered)
        {
            tooltip = "Press E to Cover";
            user.GetPlayerCoverController().Uncover(respawnPos.position);

            if (graphics != null)
                graphics.SetBool("isOpened", true);
        }
        else
        {
            tooltip = "Press E to Uncover";
            user.GetPlayerCoverController().Cover(transform.position);

            if (graphics != null)
                graphics.SetBool("isOpened", false);
        }
    }
}
