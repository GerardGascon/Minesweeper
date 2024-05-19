using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependencies : MonoBehaviour
{
    [SerializeField]
    private Vector2Int size = new Vector2Int(10,10);
    [SerializeField]
    private int mines = 10;
    private void Start() {
        List<Vector2Int> mines1 = MineSweeperHelper.CreateRandomMines(size,this.mines);
        MineSweeper sweeper = new MineSweeper(size, mines1);
        Board board = FindObjectOfType<Board>();
        RevealCell revealCell = new RevealCell(board, sweeper);
        ToggleFlag toggleFlag = new ToggleFlag(board, sweeper);
        board.Setup(sweeper, revealCell, toggleFlag);
        GameEnd gameEnd = new GameEnd(board, sweeper);
    }
}
