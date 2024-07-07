using System;
using UnityEngine;

public static class UpdateCellDomain
{
    private static CellProperties GetCellProperties(bool isWet, bool isPlanted, bool isGrown, int cellStage)
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
    public static CellProperties GetCellProperties(Farm farm, Vector2Int pos)
    {
        var x = pos.x;
        var y = pos.y;
        return GetCellProperties(farm.IsWet(x,y), farm.IsPlanted(x,y), farm.IsGrown(x,y), farm.GetCellStage(x,y));
    }

}

public struct CellProperties
{
    public Color cellColor;
    public string cellText;
}
