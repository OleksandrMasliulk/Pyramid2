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
    }

    private void Start()
    {
        objectsToInterract = new List<InterractComponent>();
    }

    public void AddToList(InterractComponent objectToInterract)
    {
        objectsToInterract.Add(objectToInterract);

        playerController.GetPlayerHUDContorller().SetTooltipText(objectToInterract.GetComponent<IInterractible>().tooltip);
        playerController.GetPlayerHUDContorller().ShowTooltip();
    }
    
    public void RemoveFromList(InterractComponent objectToInterract)
    {
        objectsToInterract.Remove(objectToInterract);

        if (objectsToInterract.Count == 0) 
        {
            playerController.GetPlayerHUDContorller().HideTooltip();
        }
        else
        {
            playerController.GetPlayerHUDContorller().SetTooltipText(objectsToInterract[0].GetComponent<IInterractible>().tooltip);
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
