using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    private static bool _isRunningSession = false;
    public static Action OnUISessionStarted;
    public static Action OnUISessionEnded;

    private Stack<UIPanel> _panelsOpened;

    [SerializeField] private EventSystem _eventSystem;

    private PlayerControls _controls;
    private void Awake()
    {
        _panelsOpened = new Stack<UIPanel>();
        _controls = new PlayerControls();
    }

    private void AddOpenedPanel(UIPanel panel)
    {
        if (_panelsOpened.Contains(panel))
            return;

        Debug.LogWarning("Panel added to stack");

        _panelsOpened.Push(panel);
        _eventSystem.SetSelectedGameObject(panel.FirstSelected);

        StartUISession();
    }

    private void CloseCurrentPanel(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.LogWarning("Cancel action");

        if (_panelsOpened.Count <= 0)
            return;

        UIPanel panel = _panelsOpened.Peek();
        panel.DisablePanel();
    }

    private void DisablePanel(UIPanel panel)
    {
        if (!_panelsOpened.Contains(panel))
            return;

        _panelsOpened.Pop();

        if (_panelsOpened.Count > 0)
            _panelsOpened.Peek().EnablePanel();

        if (_panelsOpened.Count == 0)
            EndUISession();
    }

    private void StartUISession()
    {
        if (_isRunningSession)
            return;

        Debug.LogWarning("UI Session started");

        _isRunningSession = true;
        _controls.UI.Enable();

        OnUISessionStarted?.Invoke();
    }

    private  void EndUISession()
    {
        if (!_isRunningSession)
            return;

        Debug.LogWarning("UI Session ended");

        _isRunningSession = false;
        _controls.UI.Disable();
        _panelsOpened.Clear();

        OnUISessionEnded?.Invoke();
    }

    private void OnEnable()
    {
        Debug.LogWarning("UIController enabled");

        UIPanel.OnEnabled += AddOpenedPanel;
        UIPanel.OnDisabled += DisablePanel;
        //PlayerInputController.OnCallUI += StartUISession;
        _controls.UI.Cancel.performed += CloseCurrentPanel;
    }

    private void OnDisable()
    {
        Debug.Log("UIController disabled");

        UIPanel.OnEnabled -= AddOpenedPanel;
        UIPanel.OnDisabled -= DisablePanel;
        //PlayerInputController.OnCallUI -= StartUISession;
        _controls.UI.Cancel.performed -= CloseCurrentPanel;
    }

    private void OnLevelWasLoaded(int index) 
    {
        _panelsOpened.Clear();
    }
}
