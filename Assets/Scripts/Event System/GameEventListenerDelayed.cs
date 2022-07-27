using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerDelayed : GameEventListener
{
    [SerializeField] private UnityEvent _delayedEvent;
    [SerializeField] private float _delay;

    public override void RunEvent()
    {
        base.RunEvent();

        StartCoroutine(DelayedEvent());
    }

    IEnumerator DelayedEvent()
    {
        yield return new WaitForSeconds(_delay);
        _delayedEvent?.Invoke();
    }
}