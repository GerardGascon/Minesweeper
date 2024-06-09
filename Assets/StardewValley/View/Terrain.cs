using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour, FarmRenderer
{
    TerrainCell[] cells;

    public void UpdateFarm(Farm domain)
    {
        foreach (TerrainCell cell in cells)
        {
            bool isWet = domain.IsWet(cell.x, cell.y);
        }
    }

    private void Awake()
    {
        cells = FindObjectsOfType<TerrainCell>();
    }
}
