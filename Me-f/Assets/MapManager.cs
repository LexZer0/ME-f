using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapManager
{
    public static Tile[,] map;
}
[Serializable]
public class Tile
{
    public int XPosition;
    public int YPosition;
    [NonSerialized]
    public GameObject baseObject;
}
[Serializable]
public class Position
{
    public int x;
    public int y;
}
[Serializable]
public class Wall
{
    public List<Position> positions;
    public string direction;
    public int length;
    public bool hasFeature = false;
}
[Serializable]
public class Feature
{
    public List<Position> positions;
    public Wall[] walls;
    public string type;
    public int width;
    public int height;
}