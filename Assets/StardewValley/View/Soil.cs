using System;
using StardewValley.Domain;
using StardewValley.View;
using UnityEngine;
using UnityEngine.UI;

public class Soil : MonoBehaviour {
    [SerializeField] private Vector2Int cellPosition;
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
        plantSeed.Run(cellPosition.x, cellPosition.y);
    }

    private void Water() 
    {
        water.Run(cellPosition.x, cellPosition.y);
    }

    public void UpdateCell(Farm domain)
    {
        var newProperties = UpdateCellDomain.GetCellProperties(domain, cellPosition);

        SetText(newProperties.cellText);
        SetColor(newProperties.cellColor);
    }

    private void SetColor(Color cellColor)
    {
        GetComponent<Image>().color = cellColor;
    }

    private void SetText(string cellText)
    {
        GetComponentInChildren<Text>().text = cellText;
    }

}
