using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour, View
{
    [SerializeField] private Transform board;
    [SerializeField] private GameObject cellPrefab;
    MineSweeper sweeper;
    RevealCell revealCell;
    private Cell[,] cellMatrix;


    public void Setup(MineSweeper sweeper, RevealCell revealCell)
    {
        this.sweeper = sweeper;
        this.revealCell = revealCell;
        cellMatrix = new Cell[sweeper.Size.x, sweeper.Size.y];
        PrepareBoard(sweeper);
    }

    public void PrepareBoard(MineSweeper sweeper)
    {
        for (int i = sweeper.Size.x - 1; i >= 0; i--)
        {
            for (int j = 0; j < sweeper.Size.y; j++)
                InstantiateCell(i, j);
        }
    }

    private void InstantiateCell(int i, int j)
    {
        GameObject newCell = Instantiate(cellPrefab, Vector2.zero, Quaternion.identity);
        newCell.transform.SetParent(board);
        newCell.GetComponent<Cell>().SetCellPosition(i, j);
        newCell.GetComponent<Cell>().revealCell = revealCell;
        newCell.GetComponent<Cell>().Configure(sweeper, i, j);
        cellMatrix[i, j] = newCell.GetComponent<Cell>();
    }

    public void UpdateCell(int x, int y)
    {
        cellMatrix[x,y].Configure(sweeper, x, y);
    }

    public void GameEnd(string text)
    {
        throw new System.NotImplementedException();
    }
}
