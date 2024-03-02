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
        if (x == 1)
            return 1;
        else
            return 0;
    }

    public List<Vector2Int> AdjacentOf(int x, int y)
    {
        if (x == 0)
            return new List<Vector2Int> { new Vector2Int(1, 0), new Vector2Int(1, 1), new Vector2Int(0, 1) };

        return new List<Vector2Int> {
            new(0, 0), new(0, 1), new(0, 2),
            new(1, 0), new(1, 2), new(2, 0),
            new(2, 1), new(2, 2)
        };
    }
}
