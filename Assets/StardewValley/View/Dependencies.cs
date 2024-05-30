using System;
using UnityEngine;

namespace StardewValley.View {
	public class Dependencies : MonoBehaviour {
		public Farm farm { private set; get; }

		private void Awake() {
			farm = new Farm();
		}
	}
}