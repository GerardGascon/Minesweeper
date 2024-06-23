
using System;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    private List<Cell> cells = new();

    private List<Vector2Int> wateredCells = new();
    private List<Vector2Int> plantedCells = new();

    public void Water(int x, int y)
    {
        wateredCells.Add(new Vector2Int(x, y));
        cells.Add(new Cell(x,y));
    }

    public bool IsWet(int x, int y) {
        return wateredCells.Contains(new Vector2Int(x, y));
    }

    public void PassDay()
    {
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
