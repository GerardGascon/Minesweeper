
using System;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    
    private Dictionary<(int,int), Cell> cells = new();

    private List<Vector2Int> wateredCells = new();
    private List<Vector2Int> plantedCells = new();

    private void Dig(int x, int y)
    {
        cells[(x, y)] = new();
    }

    public void Water(int x, int y)
    {
        wateredCells.Add(new Vector2Int(x, y));
        Dig(x, y);
        cells[(x, y)].isWet = true;
    }

    public bool IsWet(int x, int y) {
        return cells.ContainsKey((x,y)) && cells[(x, y)].isWet;
    }

    public void PassDay()
    {
        foreach (var keyValue in cells.Values)
        {
            keyValue.isWet = false;
        }

        wateredCells.Clear();
    }

    public void PlantSeed(int x, int y)
    {
        plantedCells.Add(new Vector2Int(x, y));
    }

    public bool HasSeed(int x, int y) {
        return plantedCells.Contains(new Vector2Int(x, y));
    }

    public bool IsGrown(int x, int y) {
        return true;
    }
}
