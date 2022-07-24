using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static Vector3 GetRandomPositionInRadius2D(Vector2 center, float radius)
    {
        Vector2 randomDirection = new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius));
        Debug.DrawLine(center, center + randomDirection, Color.red, 10f);
        return center + randomDirection;
    }
}
