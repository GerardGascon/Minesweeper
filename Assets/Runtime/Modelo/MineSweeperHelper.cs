using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MineSweeperHelper
{
    public static List<Vector2Int> CreateRandomMines(Vector2Int size, int mines)
    {
        if (size.x * size.y < mines)
            throw new ArgumentOutOfRangeException("Más minas que casillas");
        if (mines < 1)
            throw new ArgumentOutOfRangeException("No hay minas o son negativas");

        List<Vector2Int> availableCells = new();
        List<Vector2Int> mineList = new();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                availableCells.Add(new Vector2Int(i, j));
            }
        }

        for (int i = 0; i < mines; i++)
        {
            int randomCell = UnityEngine.Random.Range(0, availableCells.Count);
            mineList.Add(availableCells[randomCell]);
            availableCells.RemoveAt(randomCell);
        }

        return mineList;
    }
}
