using System;
using UnityEngine;

namespace StardewValley.View {
	public class Dependencies : MonoBehaviour {
		private PlantSeed plantSeed;
		public Farm farm { private set; get; }
		public Water water { private set; get; }
		private PassDay passDay;

		private void Awake() {
			farm = new Farm();
			water = new Water(farm, FindObjectOfType<Terrain>());
			passDay = new PassDay(farm, FindObjectOfType<Terrain>());
			plantSeed = new PlantSeed(farm, FindObjectOfType<Terrain>());

			foreach (var soil in FindObjectsOfType<Soil>())
			{
				soil.Inject(plantSeed, water);
            }
			FindObjectOfType<PassDayButton>().Inject(passDay);
		}
	}
}