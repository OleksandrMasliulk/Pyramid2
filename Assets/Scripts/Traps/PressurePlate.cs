using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private UnityEvent _onStepEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterBase>())
            _onStepEvent?.Invoke();
    }
}
