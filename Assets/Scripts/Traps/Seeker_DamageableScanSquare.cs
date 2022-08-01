using System;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_DamageableScanSquare : MonoBehaviour, ISeeker<IDamageable> {
    public event Action<IDamageable> OnSeeked;
    public event Action<IDamageable> OnLost;

    [SerializeField] private Vector2 _bounds;
    public List<IDamageable> ObjectsSeeked => ScanObjectsSquare();
    [SerializeField] private LayerMask _layer;
    public LayerMask Layer => _layer;

    public List<IDamageable> ScanObjectsSquare() {
        var overlaped = Physics2D.OverlapBoxAll(transform.position, _bounds, 0f, _layer);
        List<IDamageable> sanityList = new List<IDamageable>();

        foreach (Collider2D col in overlaped) {
            if (col.TryGetComponent<IDamageable>(out IDamageable d))
                sanityList.Add(d);
        }

        return sanityList;
    }

    [SerializeField] private Color _gizmosColor;
    private void OnDrawGizmos() {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireCube(transform.position, _bounds);
    }
}
