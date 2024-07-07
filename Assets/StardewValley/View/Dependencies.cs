using System;
using UnityEngine;

namespace StardewValley.View {
	public class Dependencies : MonoBehaviour {
        public PlantSeed plant { private set; get; }
		public Farm farm { private set; get; }
		public Water water { private set; get; }
		public PassDay passday { private set; get; }

		private void Awake() {
			farm = new Farm();
			water = new Water(farm, FindObjectOfType<Terrain>());
			passday = new PassDay(farm, FindObjectOfType<Terrain>());
			plant = new PlantSeed(farm, FindObjectOfType<Terrain>());
		}
	}
}