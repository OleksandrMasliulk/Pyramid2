using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterractionController : MonoBehaviour
{
    public Text interractTooltip;

    private List<Interractible> objectsToInterract;

    private void Start()
    {
        objectsToInterract = new List<Interractible>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interract();
        }
    }

    public void SetTooltipText(string newText)
    {
        interractTooltip.text = newText;
    }

    public void ShowTooltip()
    {
        interractTooltip.gameObject.SetActive(true);
    }

    public void HideTooltip()
    {
        interractTooltip.gameObject.SetActive(false);
    }

    public void AddToList(Interractible objectToInterract)
    {
        objectsToInterract.Add(objectToInterract);

        SetTooltipText(objectToInterract.tooltip);
        ShowTooltip();
    }
    
    public void RemoveFromList(Interractible objectToInterract)
    {
        objectsToInterract.Remove(objectToInterract);

        if (objectsToInterract.Count == 0) 
        {
            HideTooltip();
        }
        else
        {
            SetTooltipText(objectsToInterract[^1].tooltip);
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
