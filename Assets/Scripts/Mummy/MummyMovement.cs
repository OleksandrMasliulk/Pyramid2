using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMovement : MonoBehaviour
{
    public void MoveTo(Vector3 pos, float speed)
    {
        Vector3 dir = (pos - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);
    }
}
