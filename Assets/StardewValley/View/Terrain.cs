using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour, FarmRenderer
{
    Soil[] cells;

    public void UpdateFarm(Farm domain)
    {
        foreach (Soil cell in cells)
        {
            cell.UpdateCell(domain);
        }
    }

    private void Awake()
    {
        cells = FindObjectsOfType<Soil>();
    }
}
