using System;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_SanityScanCircle : MonoBehaviour, ISeeker<IHaveSanity> {
    public event Action<IHaveSanity> OnSeeked;
    public event Action<IHaveSanity> OnLost;

    [SerializeField] private float _radius;
    public List<IHaveSanity> ObjectsSeeked => ScanObjectsCircle();
    [SerializeField] private LayerMask _layer;
    public LayerMask Layer => _layer;

    public List<IHaveSanity> ScanObjectsCircle() {
        var overlaped = Physics2D.OverlapCircleAll(transform.position, _radius, _layer);
        List<IHaveSanity> sanityList = new List<IHaveSanity>();
        foreach(Collider2D col in overlaped) {
            if (col.TryGetComponent<IHaveSanity>(out IHaveSanity san))
                sanityList.Add(san);
        }

        return sanityList;
    }

    [SerializeField] private Color _gizmosColor;
    private void OnDrawGizmos() {
        Gizmos.color = _gizmosColor;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
