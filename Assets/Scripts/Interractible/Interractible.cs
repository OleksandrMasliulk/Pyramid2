using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractible : MonoBehaviour
{
    public string tooltip;

    [SerializeField]protected bool isActive;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
    }

    public bool Interract(PlayerController user)
    {
        if (isActive)
        {
            Action(user);
        }

        return isActive;
    }

    public virtual void Action(PlayerController user)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            PlayerController pc = collision.GetComponent<PlayerController>();

            if (pc != null)
            {
                pc.GetPlayerInterractionController().AddToList(this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isActive)
        {
            PlayerInterractionController pic = collision.GetComponent<PlayerInterractionController>();

            if (pic != null)
            {
                pic.RemoveFromList(this);
            }
        }
    }
}
