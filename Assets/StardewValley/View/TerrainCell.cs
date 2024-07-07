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
