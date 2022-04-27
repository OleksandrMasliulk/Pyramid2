using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance { get; private set; }

    public LayerMask obstacleLayers;
    [SerializeField]private Collider2D walkableMap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private bool IsPointInsideMap(Vector3 point)
    {
        return walkableMap.OverlapPoint(point);
    }

    public bool IsPointWalkable(Vector3 point)
    {
        if (!IsPointInsideMap(point))
        {
            return false;
        }

        Collider2D[] cols = Physics2D.OverlapCircleAll(point, .25f, obstacleLayers);
        if (cols.Length > 0)
        {
            return false;
        }

        return true;
    }
}