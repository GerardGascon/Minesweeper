
using System;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    private List<Vector2Int> wateredCells = new();

    public void Water(int x, int y)
    {
        wateredCells.Add(new Vector2Int(x, y));
    }

    public bool IsWet(int x, int y) {
        return wateredCells.Contains(new Vector2Int(x, y));
    }

    public void PassDay()
    {
        wateredCells.Clear();
    }

    public void PlantSeed(int v1, int v2)
    {
        throw new NotImplementedException();
    }

    public bool? HasSeed(int v1, int v2)
    {
        throw new NotImplementedException();
    }
}
