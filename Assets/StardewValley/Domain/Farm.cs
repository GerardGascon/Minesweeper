
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
        return cells.ContainsKey((x,y)) && cells[(x, y)].isWet;
    }

    public void PassDay()
    {
        foreach (var keyValue in cells.Values)
        {
            if (keyValue.isPlanted && keyValue.isWet)
                keyValue.isGrown = true;

            keyValue.isWet = false;
        }
    }

    public void PlantSeed(int x, int y)
    {
        Dig(x, y);
        cells[(x, y)].isPlanted = true;
    }

    public bool HasSeed(int x, int y) {
        return cells.ContainsKey((x, y)) && cells[(x, y)].isPlanted;
    }

    public bool IsGrown(int x, int y) {
        return cells.ContainsKey((x, y)) && cells[(x, y)].isGrown;
    }
}
