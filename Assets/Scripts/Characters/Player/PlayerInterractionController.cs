using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerInterractionController : MonoBehaviour
{
    private PlayerController playerController;

    private List<InterractComponent> objectsToInterract;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        objectsToInterract = new List<InterractComponent>();
    }

    public void AddToList(InterractComponent objectToInterract)
    {
        objectsToInterract.Add(objectToInterract);

        playerController.HUDController.SetTooltipText(objectToInterract.GetComponent<IInterractible>().Tooltip);
        playerController.HUDController.ShowTooltip();
    }
    
    public void RemoveFromList(InterractComponent objectToInterract)
    {
        objectsToInterract.Remove(objectToInterract);

        if (objectsToInterract.Count == 0) 
        {
            playerController.HUDController.HideTooltip();
        }
        else
        {
            playerController.HUDController.SetTooltipText(objectsToInterract[0].GetComponent<IInterractible>().Tooltip);
        }
    } 

    public void Interract()
    {
        if (objectsToInterract.Count > 0)
        {
            objectsToInterract[0].Interract(playerController);
            //if (!objectsToInterract[^1].Interract(playerController))
            //{
            //    RemoveFromList(objectsToInterract[^1]);
            //}
        }
        else
        {
            Debug.Log("No objects to interract");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InterractComponent obj = collision.GetComponent<InterractComponent>();

        if (obj != null)
        {
            AddToList(obj);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InterractComponent obj = collision.GetComponent<InterractComponent>();

        if (obj != null)
        {
            RemoveFromList(obj);
        }
    }
}
