using System;
using UnityEngine;

public static class UpdateCellDomain
{
    public static CellProperties GetCellProperties(bool isWet, bool isPlanted, bool isGrown, int cellStage)
    {
        CellProperties newCellProperties = new();

        if (isWet)
            newCellProperties.cellColor = Color.blue;
        else
            newCellProperties.cellColor = Color.white;

        if (isGrown)
            newCellProperties.cellText = $"Stage: {cellStage}";
        else if (isPlanted)
            newCellProperties.cellText = "Planted";
        else
            newCellProperties.cellText = "Empty";

        return newCellProperties;
    }

}

public struct CellProperties
{
    public Color cellColor;
    public string cellText;
}
