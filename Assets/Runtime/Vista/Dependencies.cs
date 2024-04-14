using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependencies : MonoBehaviour
{
    private void Start()
    {
        List<Vector2Int> minas;

        minas = new List<Vector2Int>() 
        {
        new Vector2Int(0, 0),
        new Vector2Int(1, 0),
        new Vector2Int(0, 2),
        new Vector2Int(0, 3),
        new Vector2Int(5, 0),
        new Vector2Int(2, 4),
        new Vector2Int(5, 6),
        new Vector2Int(9, 9),
        new Vector2Int(2, 6),
        new Vector2Int(8, 3),
        new Vector2Int(3, 3),
        new Vector2Int(3, 5)
        };

        MineSweeper sweeper = new MineSweeper(new Vector2Int(10, 10), minas);
        Board board = FindObjectOfType<Board>();
        RevealCell revealCell = new RevealCell(board, sweeper);
        board.Setup(sweeper, revealCell);
        ToggleFlag toggleFlag = new ToggleFlag(board, sweeper);
        GameEnd gameEnd = new GameEnd(board, sweeper);     
    }
}
