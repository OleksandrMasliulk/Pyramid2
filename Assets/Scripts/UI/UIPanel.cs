using UnityEngine;
using System;
using UnityEngine.Events;

public class UIPanel : MonoBehaviour
{
    public static Action<UIPanel> OnEnabled;
    public static Action<UIPanel> OnDisabled;

    [SerializeField] private UnityEvent OnDisable;

    [SerializeField] private GameObject _firstSelected;
    public GameObject FirstSelected => _firstSelected;

    public virtual void EnablePanel()
    {
        gameObject.SetActive(true);
        OnEnabled?.Invoke(this);
    }

    public virtual void DisablePanel()
    {
        OnDisable?.Invoke();
    }

    public void ThrowDisabledAction() 
    {
        OnDisabled?.Invoke(this);
    }
}
