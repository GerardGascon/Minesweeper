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

    public void UpdateCell(Farm domain)
    {
        bool isWet = domain.IsWet(cellPosition.x, cellPosition.y);
        bool isPlanted = domain.IsPlanted(cellPosition.x, cellPosition.y);
        bool isGrown = domain.IsGrown(cellPosition.x, cellPosition.y);
        int cellStage = domain.GetCellStage(cellPosition.x, cellPosition.y);

        var newProperties = UpdateCellDomain.GetCellProperties(isWet,isPlanted,isGrown,cellStage);

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
