using UnityEngine;

public class Cell
{
    private Vector2Int position;
    public bool isWet;
    private bool isPlanted;
    private bool isGrown;
    private int x;
    private int y;

    public Cell(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
