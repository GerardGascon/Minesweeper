using System;
using StardewValley.Domain;
using UnityEngine;

namespace StardewValley.View {
	public class Dependencies : MonoBehaviour {

		private void Awake() {
			var farm = new Farm();
			var water = new Water(farm, FindObjectOfType<Terrain>());
			var passDay = new PassDay(farm, FindObjectOfType<Terrain>());
			var plantSeed = new PlantSeed(farm, FindObjectOfType<Terrain>());

			Soil[] soils = FindObjectsOfType<Soil>();
			foreach (var soil in soils)
			{
				soil.Inject(plantSeed, water);
            }
			FindObjectOfType<Terrain>().Inject(soils);
			FindObjectOfType<PassDayButton>().Inject(passDay);
		}
	}
}