using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeper 
{
    private List<Vector2Int> cellsRevealed = new List<Vector2Int>();
    private List<Vector2Int> mines = new List<Vector2Int>();
    public MineSweeper(Vector2Int Mina) {
        mines.Add(Mina);
    }
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
        return mines.Contains(new Vector2Int(x,y));
    }

    public int CheckAdjacentMines(int x, int y)
    {
        return 1;
    }
}
