using System;
using UnityEngine;

namespace StardewValley.View {
	public class Dependencies : MonoBehaviour {
		public Farm farm { private set; get; }
		public Water water { private set; get; }

		private void Awake() {
			farm = new Farm();
			water = new Water(farm, FindObjectOfType<Terrain>());
		}
	}
}