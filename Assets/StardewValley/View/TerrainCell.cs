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
        bool isWet = domain.IsWet(cellPosition.x, cellPosition.y);
        if (isWet)
            SetWet();
    }

    private void SetWet() {
        Debug.Log($"Wet {cellPosition} {name}");
    }
}
