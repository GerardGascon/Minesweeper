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
            cell.UpdateCell(domain);
        }
    }

    private void Awake()
    {
        cells = FindObjectsOfType<TerrainCell>();
    }
}
