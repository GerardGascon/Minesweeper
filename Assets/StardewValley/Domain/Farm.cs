
using System;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    private List<Cell> cells = new();
    private Dictionary<Vector2Int, Cell> djdtfubknfk = new();

    private List<Vector2Int> wateredCells = new();
    private List<Vector2Int> plantedCells = new();

    public void Water(int x, int y)
    {
        wateredCells.Add(new Vector2Int(x, y));
        cells.Add(new Cell(x,y));
        djdtfubknfk[new Vector2Int(x, y)] = new Cell(x, y);
        djdtfubknfk[new Vector2Int(x, y)].isWet = true;
    }

    public bool IsWet(int x, int y) {
        var result = wateredCells.Contains(new Vector2Int(x, y));
        var sdfs = djdtfubknfk.ContainsKey(new Vector2Int(x,y)) && djdtfubknfk[new Vector2Int(x, y)].isWet;
        Debug.Assert(result == sdfs);
        return result;
    }

    public void PassDay()
    {
        foreach (var keyValue in djdtfubknfk.Values)
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
