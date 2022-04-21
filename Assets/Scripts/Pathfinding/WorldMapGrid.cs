using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldMapGrid : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private WorldMapCell[,] grid;

    private void Awake()
    {
        InitGrid();
    }

    private void InitGrid()
    {
        Vector3Int startPoint = tilemap.origin;
        Vector3Int endPoint = tilemap.origin + tilemap.size;

        int rows = endPoint.y - startPoint.y;
        int cols = endPoint.x - startPoint.x;

        grid = new WorldMapCell[cols, rows];

        for (int i = 0; i < cols; i++)
            for (int j = 0; j < rows; j++)
            {
                Vector3 pos = tilemap.CellToWorld(new Vector3Int(startPoint.x + i, startPoint.y + j, 0));
                TileBase tile = tilemap.GetTile(new Vector3Int(startPoint.x + i, startPoint.y + j, 0));
                grid[i, j] = new WorldMapCell(pos.x + tilemap.tileAnchor.x, pos.y + tilemap.tileAnchor.y, tile);

                //Debug.Log("Cell [" + i + "," + j + "] coords: x = " + grid[i, j].xCoord + ", y = " + grid[i, j].yCoord);
            }
    }

    public WorldMapCell[,] GetWorldMapGrid()
    {
        return grid;
    }

    public int GetGridWidth()
    {
        return grid.GetLength(0);
    }

    public int GetGridHeight()
    {
        return grid.GetLength(1);
    }

    public WorldMapCell GetGridCell(float xPos, float yPos)
    {
        Vector3 worldPoint = new Vector3(xPos, yPos, 0f);
        //Vector3Int tilemapCoords = tilemap.WorldToCell(worldPoint);
        int x, y;
        GetGridCoords(worldPoint, out x, out y);

        return grid[x, y];
    }

    public WorldMapCell GetGridCell(int x, int y)
    {
        return grid[x, y];
    }

    public void GetGridCoords(Vector3 worldPos, out int x, out int y)
    {
        Vector3Int tilemapPos = tilemap.WorldToCell(worldPos);
        tilemapPos.x -= tilemap.origin.x;
        tilemapPos.y -= tilemap.origin.y;
        tilemapPos.z = 0;

        Debug.Log("Grid Pos: " + tilemapPos);

        x = tilemapPos.x;
        y = tilemapPos.y;
        //return tilemapPos;
    }

    //private void ondrawgizmos()
    //{
    //    for (int i = 0; i < getgridwidth(); i++)
    //        for (int j = 0; j < getgridheight(); j++)
    //        {
    //            gizmos.drawwiresphere(new vector3(grid[i, j].xcoord, grid[i, j].ycoord, 0f), .3f);

    //            debug.log("cell [" + i + "," + j + "] coords: x = " + grid[i, j].xcoord + ", y = " + grid[i, j].ycoord);
    //        }
    //}
}
