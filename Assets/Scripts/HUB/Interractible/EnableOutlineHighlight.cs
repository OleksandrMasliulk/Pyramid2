using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOutlineHighlight : MonoBehaviour, IHighlight
{
    [SerializeField] private GameObject _highlightObject;

    private void Awake()
    {
        UnHighlight();
    }

    public void Highlight()
    {
        _highlightObject.SetActive(true);
    }

    public void UnHighlight()
    {
        _highlightObject.SetActive(false);
    }


}
