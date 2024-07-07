using System.Collections;
using System.Collections.Generic;
using StardewValley.Domain;
using UnityEngine;
using Soil = StardewValley.View.Soil;

public class Terrain : MonoBehaviour, FarmRenderer
{
    Soil[] soils;

    public void Inject(Soil[] soils) {
        this.soils = soils;
    }

    public void UpdateFarm(Farm domain)
    {
        foreach (Soil soil in soils)
        {
            soil.UpdateCell(domain);
        }
    }
}
