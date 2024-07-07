using StardewValley.Domain;
using UnityEngine;

namespace StardewValley.View {
    public static class UpdateSoilDomain
    {
        private static SoilProperties GetSoilProperties(bool isWet, bool isPlanted, bool isGrown, int growStage)
        {
            SoilProperties newSoilProperties = new();

            if (isWet)
                newSoilProperties.color = Color.blue;
            else
                newSoilProperties.color = Color.white;

            if (isGrown)
                newSoilProperties.text = $"Stage: {growStage}";
            else if (isPlanted)
                newSoilProperties.text = "Planted";
            else
                newSoilProperties.text = "Empty";

            return newSoilProperties;
        }
        public static SoilProperties GetSoilProperties(Farm farm, Vector2Int pos)
        {
            var x = pos.x;
            var y = pos.y;
            return GetSoilProperties(farm.IsWet(x,y), farm.IsPlanted(x,y), farm.IsGrown(x,y), farm.GetSoilStage(x,y));
        }

    }

    public struct SoilProperties
    {
        public Color color;
        public string text;
    }
}