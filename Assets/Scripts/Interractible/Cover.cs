using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cover : MonoBehaviour, IInterractible
{
    [SerializeField] private Transform respawnPos;
    [SerializeField] private Animator graphics;
    [SerializeField] private GameObject dustPS;

    public string tooltip { get; set; }

    private void Start()
    {
        tooltip = "Press E to Cover";
    }

    public void Interract(PlayerController user)
    {
        if (user.Stats.IsCovered)
        {
            tooltip = "Press E to Cover";
            user.CoverController.Uncover(respawnPos.position);
            Instantiate(dustPS, respawnPos.position, Quaternion.identity);

            if (graphics != null)
                graphics.SetBool("isOpened", true);
        }
        else
        {
            tooltip = "Press E to Uncover";
            user.CoverController.Cover(transform.position);

            if (graphics != null)
                graphics.SetBool("isOpened", false);
        }
    }
}
