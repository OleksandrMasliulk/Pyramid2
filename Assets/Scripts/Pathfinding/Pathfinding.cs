using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public static Pathfinding Instance { get; set; }

    private static float STRAIGHT_MOVE_COST = 10f;
    private static float DIAGONAL_MOVE_COST = 14f;

    [SerializeField] private WorldMapGrid grid;

    [SerializeField] private PathfindingNode[,] pathfindingGrid;

    private List<PathfindingNode> openList;
    private List<PathfindingNode> closedList;

    public LayerMask notWalkable;

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

    private void Start()
    {
        InitGrid();
    }

    private void InitGrid()
    {
        pathfindingGrid = new PathfindingNode[grid.GetGridWidth(), grid.GetGridHeight()];

        for (int i = 0; i < GetPathfindingGridWidth(); i++)
            for (int j = 0; j < GetPathfindingGridHeight(); j++)
            {
                bool isWalkable;
                Collider2D col = Physics2D.OverlapBox(new Vector2(grid.GetGridCell(i, j).xCoord, grid.GetGridCell(i, j).yCoord), new Vector2(.3f, .3f), 0f, notWalkable);
                if (grid.GetGridCell(i, j) == null || col != null)
                {
                    isWalkable = false;
                }
                else
                {
                    isWalkable = true;
                }
                pathfindingGrid[i, j] = new PathfindingNode(i, j, grid.GetGridCell(i, j), isWalkable);
            }
    }

    public List<PathfindingNode> FindPath(float startX, float startY, float endX, float endY)
    {
        Debug.ClearDeveloperConsole();

        int startGridX, startGridY;
        int endGridX, endGridY;
        Vector3 startWPos = new Vector3(startX, startY, 0f);
        Vector3 endWPos = new Vector3(endX, endY, 0f);

        grid.GetGridCoords(startWPos, out startGridX, out startGridY);
        grid.GetGridCoords(endWPos, out endGridX, out endGridY);

        if (startGridX >= GetPathfindingGridWidth() || endGridX >= GetPathfindingGridWidth() 
            || startGridY >= GetPathfindingGridHeight() || endGridY >= GetPathfindingGridHeight())
        {
            Debug.Log("Out of pathfinding grid bounds");
            return null;
        }
            

        PathfindingNode startNode = pathfindingGrid[startGridX, startGridY];
        PathfindingNode endNode = pathfindingGrid[endGridX, endGridY];

        Debug.LogWarning("START: " + startNode.pathfindingGridX + ", " + startNode.pathfindingGridY);
        Debug.LogWarning("END: " + endNode.pathfindingGridX + ", " + endNode.pathfindingGridY);

        openList = new List<PathfindingNode> { startNode };
        closedList = new List<PathfindingNode>();

        for (int i = 0; i < GetPathfindingGridWidth(); i++)
            for (int j = 0; j < GetPathfindingGridHeight(); j++)
            {
                PathfindingNode node = pathfindingGrid[i, j];
                node.gCost = int.MaxValue;
                node.CalculateFCost();
                node.cameFromNode = null;
            }

        startNode.gCost = 0f;
        startNode.hCost = CalculateHCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            PathfindingNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                return GetFinalPath(currentNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathfindingNode neighbourNode in GetNeighboursList(currentNode))
            {
                if (closedList.Contains(neighbourNode) || neighbourNode == null)
                    continue;

                float tentGCost = currentNode.gCost + CalculateHCost(currentNode, neighbourNode);
                if (tentGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentGCost;
                    neighbourNode.hCost = CalculateHCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
            }
        }

        Debug.Log("NO PATH FOUND!");
        return null;
    }

    private List<PathfindingNode> GetNeighboursList(PathfindingNode node)
    {
        List<PathfindingNode> neighboursList = new List<PathfindingNode>();


        //LEFT
        if (node.pathfindingGridX - 1 >= 0 && pathfindingGrid[node.pathfindingGridX - 1, node.pathfindingGridY].isWalkable)
        {
            neighboursList.Add(pathfindingGrid[node.pathfindingGridX - 1, node.pathfindingGridY]);
        }

        //RiGHT
        if (node.pathfindingGridX + 1 < GetPathfindingGridWidth() && pathfindingGrid[node.pathfindingGridX + 1, node.pathfindingGridY].isWalkable)
        {
            neighboursList.Add(pathfindingGrid[node.pathfindingGridX + 1, node.pathfindingGridY]);
        }

        //BOTTOM LEFT
        if (node.pathfindingGridY - 1 >= 0 && pathfindingGrid[node.pathfindingGridX, node.pathfindingGridY - 1].isWalkable)
        {
            neighboursList.Add(pathfindingGrid[node.pathfindingGridX, node.pathfindingGridY - 1]);
        }

        //BOTTOM RIGHT
        if (node.pathfindingGridX + 1 < GetPathfindingGridWidth() && node.pathfindingGridY - 1 >= 0 && pathfindingGrid[node.pathfindingGridX + 1, node.pathfindingGridY - 1].isWalkable)
        {
            neighboursList.Add(pathfindingGrid[node.pathfindingGridX + 1, node.pathfindingGridY - 1]);
        }

        //TOP RIGHT
        if (node.pathfindingGridX + 1 < GetPathfindingGridWidth() && node.pathfindingGridY + 1 < GetPathfindingGridHeight() && pathfindingGrid[node.pathfindingGridX + 1, node.pathfindingGridY + 1].isWalkable)
        {
            neighboursList.Add(pathfindingGrid[node.pathfindingGridX + 1, node.pathfindingGridY + 1]);
        }

        //TOP LEFT
        if (node.pathfindingGridY + 1 < GetPathfindingGridHeight() && pathfindingGrid[node.pathfindingGridX, node.pathfindingGridY + 1].isWalkable)
        {
            neighboursList.Add(pathfindingGrid[node.pathfindingGridX, node.pathfindingGridY + 1]);
        }

        return neighboursList;
    }

    private List<PathfindingNode> GetFinalPath(PathfindingNode endNode)
    {
        List<PathfindingNode> path = new List<PathfindingNode>();
        path.Add(endNode);
        PathfindingNode currentNode = endNode;

        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }

        path.Reverse();
        DrawPath(path);

        return path;
    }

    private float CalculateHCost(PathfindingNode start, PathfindingNode end)
    {
        float xDist = Mathf.Abs(start.pathfindingGridX - end.pathfindingGridX);
        float yDist = Mathf.Abs(start.pathfindingGridY - end.pathfindingGridY);
        float rem = Mathf.Abs(xDist - yDist);

        return DIAGONAL_MOVE_COST * Mathf.Min(xDist, yDist) + rem * STRAIGHT_MOVE_COST;
    }

    private PathfindingNode GetLowestFCostNode(List<PathfindingNode> nodeList)
    {
        PathfindingNode lowestFCostNode = nodeList[0];
        for (int i = 1; i < nodeList.Count; i++)
        {
            if (nodeList[i].fCost < lowestFCostNode.fCost)
                lowestFCostNode = nodeList[i];
        }

        return lowestFCostNode;
    }

    private int GetPathfindingGridWidth()
    {
        return pathfindingGrid.GetLength(0);
    }

    private int GetPathfindingGridHeight()
    {
        return pathfindingGrid.GetLength(1);
    }

    public PathfindingNode GetNodeAtWorldPos(Vector3 worldPos) 
    {
        grid.GetGridCoords(worldPos, out int x, out int y);
        return pathfindingGrid[x, y];
    }

    private void DrawPath(List<PathfindingNode> path)
    {
        for (int i = 0; i < path.Count - 1; i++)
        {
            Debug.DrawLine(path[i].GetWorldPos(), path[i + 1].GetWorldPos(), Color.red, 10f);
        }
    }
}
