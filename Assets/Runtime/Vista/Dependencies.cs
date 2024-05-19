using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependencies : MonoBehaviour
{
    private void Start()
    {
        MineSweeper sweeper = new MineSweeper(new Vector2Int(10, 10), 10);
        Board board = FindObjectOfType<Board>();
        RevealCell revealCell = new RevealCell(board, sweeper);
        ToggleFlag toggleFlag = new ToggleFlag(board, sweeper);
        board.Setup(sweeper, revealCell, toggleFlag);
        GameEnd gameEnd = new GameEnd(board, sweeper);     
    }
}
