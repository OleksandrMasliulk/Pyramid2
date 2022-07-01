using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public interface IPathfindingMove
{
    void SetTarget(Vector3 target);
    Task Move(Vector3 target);
}
