using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
public class PlayerInterractionController : MonoBehaviour
{
    private PlayerController playerController;

    private List<Interractible> objectsToInterract;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        objectsToInterract = new List<Interractible>();
    }

    private void Update()
    {
        if (playerController.GetPlayerParameters().isAlive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interract();
            }
        }
    }

    public void AddToList(Interractible objectToInterract)
    {
        objectsToInterract.Add(objectToInterract);

        playerController.GetPlayerHUDContorller().SetTooltipText(objectToInterract.tooltip);
        playerController.GetPlayerHUDContorller().ShowTooltip();
    }
    
    public void RemoveFromList(Interractible objectToInterract)
    {
        objectsToInterract.Remove(objectToInterract);

        if (objectsToInterract.Count == 0) 
        {
            playerController.GetPlayerHUDContorller().HideTooltip();
        }
        else
        {
            playerController.GetPlayerHUDContorller().SetTooltipText(objectsToInterract[^1].tooltip);
        }
    } 

    private void Interract()
    {
        if (objectsToInterract.Count > 0)
        {
            if (!objectsToInterract[^1].Interract(playerController))
            {
                RemoveFromList(objectsToInterract[^1]);
            }
            playerController.GetPlayerGraphicsController().SetInterract();
        }
        else
        {
            Debug.Log("No objects to interract");
        }
    }
}
