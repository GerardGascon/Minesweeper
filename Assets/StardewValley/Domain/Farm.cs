
using System;
using System.Collections.Generic;
using UnityEngine;

public class Farm
{
    private Dictionary<(int,int), Cell> cells = new();

    private void Dig(int x, int y) {
        if (cells.ContainsKey((x, y)))
            return;
        cells[(x, y)] = new();
    }

    public void Water(int x, int y)
    {
        Dig(x, y);
        cells[(x, y)].isWet = true;
    }

    public bool IsWet(int x, int y) {
        return In((x, y)).isWet;
    }

    public void PassDay()
    {
        foreach (var keyValue in cells.Values)
            keyValue.PassDay();
    }

    public void PlantSeed(int x, int y)
    {
        Dig(x, y);
        cells[(x, y)].isPlanted = true;
    }

    public bool IsPlanted(int x, int y) {
        return In((x, y)).isPlanted;
    }

    public bool IsGrown(int x, int y) {
        return In((x, y)).isGrown;
    }

    private Cell In((int x,int y) cell)
    {
        if (cells.ContainsKey(cell))
            return cells[cell];
        return new();
    }
}
