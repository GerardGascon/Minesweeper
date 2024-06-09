using System;
using StardewValley.View;
using UnityEngine;
using UnityEngine.UI;

public class TerrainCell : MonoBehaviour {
    [SerializeField] private Vector2Int cellPosition;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Water);
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
