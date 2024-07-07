using StardewValley.Controller;
using StardewValley.Domain;
using UnityEngine;
using UnityEngine.UI;

namespace StardewValley.View {
    public class Soil : MonoBehaviour {
        [SerializeField] private Vector2Int position;

        PlantSeed plantSeed;
        Water water;

        private void Awake()
        {
            GetComponent<ButtonClick>().leftClick += Water;
            GetComponent<ButtonClick>().rightClick += Plant;
        }
        public void Inject(PlantSeed plantSeed, Water water)
        {
            this.plantSeed = plantSeed;
            this.water = water;
        }
        private void Plant()
        {
            plantSeed.Run(position.x, position.y);
        }

        private void Water()
        {
            water.Run(position.x, position.y);
        }

        public void UpdateSoil(Farm domain)
        {
            var newProperties = UpdateSoilDomain.GetSoilProperties(domain, position);

            SetText(newProperties.text);
            SetColor(newProperties.color);
        }

        private void SetColor(Color color)
        {
            GetComponent<Image>().color = color;
        }

        private void SetText(string text)
        {
            GetComponentInChildren<Text>().text = text;
        }

    }
}
