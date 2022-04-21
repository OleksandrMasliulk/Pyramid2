using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingTest : MonoBehaviour
{
    public Pathfinding pathfinding;

    private Vector3 startPoint;
    private Vector3 endPoint;

    private void Start()
    {
        ResetPoints();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetStartPoint();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            SetDestPoint();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            CalculatePath();
            ResetPoints();
        }
    }

    private void SetStartPoint()
    {
        startPoint = GetMouseWorldPos();
    }

    private void SetDestPoint()
    {
        endPoint = GetMouseWorldPos();
    }

    private void ResetPoints()
    {
        startPoint = Vector3.zero;
        endPoint = Vector3.zero;
    }

    private void CalculatePath()
    {
        List<PathfindingNode> path = pathfinding.FindPath(startPoint.x, startPoint.y, endPoint.x, endPoint.y);
        if (path != null )
            DrawPath(path);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0f;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void DrawPath(List<PathfindingNode> path)
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            Debug.DrawLine(path[i].GetWorldPos(), path[i + 1].GetWorldPos(), Color.red, 10f);
        }
    }
}
