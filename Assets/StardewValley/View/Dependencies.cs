using System;
using UnityEngine;

namespace StardewValley.View {
	public class Dependencies : MonoBehaviour {

		private void Awake() {
			var farm = new Farm();
			var water = new Water(farm, FindObjectOfType<Terrain>());
			var passDay = new PassDay(farm, FindObjectOfType<Terrain>());
			var plantSeed = new PlantSeed(farm, FindObjectOfType<Terrain>());

			foreach (var soil in FindObjectsOfType<Soil>())
			{
				soil.Inject(plantSeed, water);
            }
			FindObjectOfType<PassDayButton>().Inject(passDay);
		}
	}
}