using System;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_PlayerTriggerCircle : MonoBehaviour, ISeeker<PlayerDrivenCharacter> {
    public event Action<PlayerDrivenCharacter> OnSeeked;
    public event Action<PlayerDrivenCharacter> OnLost;

    [SerializeField] private LayerMask _layer;
    public LayerMask Layer => _layer;
    [SerializeField] private List<PlayerDrivenCharacter> _objectsSeeked;
    public List<PlayerDrivenCharacter> ObjectsSeeked => _objectsSeeked;

    private void Awake() => _objectsSeeked = new List<PlayerDrivenCharacter>();

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.TryGetComponent<PlayerDrivenCharacter>(out PlayerDrivenCharacter component)) {
            _objectsSeeked.Add(component);
            OnSeeked?.Invoke(component);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.TryGetComponent<PlayerDrivenCharacter>(out PlayerDrivenCharacter component)) {
            _objectsSeeked.Remove(component);
            OnLost?.Invoke(component);
        }
    }
}
