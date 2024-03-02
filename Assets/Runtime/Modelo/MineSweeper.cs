using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeper 
{
    public MineSweeper(Vector2Int Mina) { }
    private List<Vector2Int> cellsRevealed = new List<Vector2Int>();
    public void Reveal(int x,int y)
    {
        cellsRevealed.Add(new Vector2Int(x,y));
    }
    public bool IsRevealed(int x, int y)
    {
        return cellsRevealed.Contains(new Vector2Int(x,y));
    }

    public bool HasMineIn(int x, int y)
    {
        return true;
    }
}
