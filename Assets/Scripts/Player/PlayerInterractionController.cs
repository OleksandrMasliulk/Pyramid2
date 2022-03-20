using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterractionController : MonoBehaviour
{
    private PlayerHUDController hud;
    private PlayerParameters parameters;

    private List<Interractible> objectsToInterract;

    private void Start()
    {
        parameters = GetComponent<PlayerParameters>();
        hud = GetComponent<PlayerHUDController>();

        objectsToInterract = new List<Interractible>();
    }

    private void Update()
    {
        if (parameters.isAlive)
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

        hud.SetTooltipText(objectToInterract.tooltip);
        hud.ShowTooltip();
    }
    
    public void RemoveFromList(Interractible objectToInterract)
    {
        objectsToInterract.Remove(objectToInterract);

        if (objectsToInterract.Count == 0) 
        {
            hud.HideTooltip();
        }
        else
        {
            hud.SetTooltipText(objectsToInterract[^1].tooltip);
        }
    } 

    private void Interract()
    {
        if (objectsToInterract.Count > 0)
        {
            if (!objectsToInterract[^1].Interract())
            {
                RemoveFromList(objectsToInterract[^1]);
            }
        }
        else
        {
            Debug.Log("No objects to interract");
        }
    }
}
