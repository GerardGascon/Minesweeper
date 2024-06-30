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

        if (domain.IsGrown(cellPosition.x, cellPosition.y))
            SetGrown();
        else if (domain.IsPlanted(cellPosition.x, cellPosition.y))
            SetPlanted();
        else
            SetNotPlanted();
    }

    private void SetWet() {
        GetComponent<Image>().color = Color.blue;
    }
    private void SetDry() {
        GetComponent<Image>().color = Color.white;
    }
    private void SetPlanted()
    {
        GetComponentInChildren<Text>().text = "Planted";
    }
    private void SetNotPlanted()
    {
        GetComponentInChildren<Text>().text = "Empty";
    }
    private void SetGrown()
    {
        GetComponentInChildren<Text>().text = "Grown";
    }

}
