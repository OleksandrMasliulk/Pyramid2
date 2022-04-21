using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldMapCell
{
    public float xCoord;
    public float yCoord;

    public TileBase tile;

    public WorldMapCell(float xCoord, float yCoord, TileBase tile)
    {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
        this.tile = tile;
    }
}
