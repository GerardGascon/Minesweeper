using System;
using StardewValley.View;
using UnityEngine;
using UnityEngine.UI;

public class TerrainCell : MonoBehaviour {
    private Farm farm;

    [SerializeField] private Vector2Int cellPosition;
    public int x => cellPosition.x;
    public int y => cellPosition.y;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Water);
    }

    private void Start() {
        farm = FindObjectOfType<Dependencies>().farm;
    }

    private void Water() 
    {
        farm.Water(cellPosition.x, cellPosition.y);
    }

}
