using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private Transform board;
    [SerializeField] private GameObject cellPrefab;
    MineSweeper sweeper;

    private void Start()
    {
        sweeper = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        PrepareBoard(sweeper);
    }

    public void PrepareBoard(MineSweeper sweeper)
    {
        for (int i = sweeper.Size.x - 1; i >= 0; i--)
        {
            for (int j = 0; j < sweeper.Size.y; j++)
                InstantateCell(i, j);
        }
    }

    private void InstantateCell(int i, int j)
    {
        GameObject newCell = Instantiate(cellPrefab, Vector2.zero, Quaternion.identity);
        newCell.transform.SetParent(board);
        newCell.GetComponent<Cell>().SetCellPosition(i, j);
    }

}
