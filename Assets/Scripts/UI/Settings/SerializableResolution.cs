using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableResolution
{
    public int width;
    public int height;

    public SerializableResolution(int _width, int _height)
    {
        width = _width;
        height = _height;
    } 
}
