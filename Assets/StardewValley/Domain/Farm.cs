using System.Collections.Generic;

namespace StardewValley.Domain {
    public class Farm
    {
        private Dictionary<(int,int), Soil> soils = new();

        private void Dig(int x, int y) {
            if (soils.ContainsKey((x, y)))
                return;
            soils[(x, y)] = new();
        }

        public void Water(int x, int y)
        {
            Dig(x, y);
            soils[(x, y)].isWet = true;
        }

        public bool IsWet(int x, int y) {
            return In((x, y)).isWet;
        }

        public void PassDay()
        {
            foreach (var keyValue in soils.Values)
                keyValue.PassDay();
        }

        public void PlantSeed(int x, int y)
        {
            Dig(x, y);
            soils[(x, y)].isPlanted = true;
        }

        public bool IsPlanted(int x, int y) {
            return In((x, y)).isPlanted;
        }

        public bool IsGrown(int x, int y) {
            return In((x, y)).isGrown;
        }

        private Soil In((int x,int y) soil)
        {
            if (soils.ContainsKey(soil))
                return soils[soil];
            return new();
        }

        public int GetSoilStage(int x, int y) {
            return In((x, y)).growStage;
        }
    }
}
