using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindingNode
{
    public WorldMapCell cell;

    public int pathfindingGridX;
    public int pathfindingGridY;

    public float gCost;
    public float fCost;
    public float hCost;

    public PathfindingNode cameFromNode;

    public bool isWalkable;
    public PathfindingNode(int pathfindingGridX, int pathfindingGridY, WorldMapCell cell, bool isWalkable)
    {
        this.pathfindingGridX = pathfindingGridX;
        this.pathfindingGridY = pathfindingGridY;
        this.cell = cell;
        this.isWalkable = isWalkable;
    }

    public float CalculateFCost()
    {
        return gCost + hCost;
    }

    public Vector3 GetWorldPos()
    {
        return new Vector3(cell.xCoord, cell.yCoord, 0f);
    }
}
