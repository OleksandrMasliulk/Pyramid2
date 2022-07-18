using UnityEngine;
using System.Collections.Generic;
using System;

public class InterractibleSeeker : MonoBehaviour, ISeeker<IInterractible>
{
    private List<IInterractible> _objectsSeeked;
    public List<IInterractible> ObjectsSeeked => _objectsSeeked;

    public event Action OnSeeked;
    public event Action OnLost;

    private void Awake()
    {
        _objectsSeeked = new List<IInterractible>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInterractible>(out IInterractible component))
        {
            _objectsSeeked.Add(component);
            OnSeeked?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IInterractible>(out IInterractible component))
        {
            _objectsSeeked.Remove(component);
            OnLost?.Invoke();
        }
    }
}
