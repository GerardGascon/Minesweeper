using System;
using StardewValley.View;
using UnityEngine;
using UnityEngine.UI;

public class TerrainCell : MonoBehaviour {
    [SerializeField] private Vector2Int cellPosition;

    private void Awake()
    {
        GetComponent<ButtonClick>().leftClick += Water;
        GetComponent<ButtonClick>().rightClick += Plant;
    }

    private void Plant()
    {
        FindObjectOfType<Dependencies>().plant.Run(cellPosition.x, cellPosition.y);
    }

    private void Water() {
        FindObjectOfType<Dependencies>().water.Run(cellPosition.x, cellPosition.y);
    }

    public void UpdateCell(Farm domain) {
        if (domain.IsWet(cellPosition.x, cellPosition.y))
            SetWet();
        else
            SetDry();
    }

    private void SetWet() {
        GetComponent<Image>().color = Color.blue;
    }
    private void SetDry() {
        GetComponent<Image>().color = Color.white;
    }
}
