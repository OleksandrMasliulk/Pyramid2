using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interractible : MonoBehaviour
{
    public string tooltip;

    protected bool isActive;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        isActive = true;
    }

    public bool Interract()
    {
        if (isActive)
        {
            Action();
        }

        return isActive;
    }

    protected virtual void Action()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive)
        {
            PlayerInterractionController pic = collision.GetComponent<PlayerInterractionController>();

            if (pic != null)
            {
                pic.AddToList(this);
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
