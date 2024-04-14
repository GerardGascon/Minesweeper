using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependencies : MonoBehaviour
{
    MineSweeper _sweeper;
    RevealCell _revealCell;
    ToggleFlag _toggleFlag;
    GameEnd _gameEnd;
    Board _board;

    private void Start()
    {
        _sweeper = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        _board = FindObjectOfType<Board>();
        _revealCell = new RevealCell(_board, _sweeper);
        _toggleFlag = new ToggleFlag(_board, _sweeper);
        _gameEnd = new GameEnd(_board, _sweeper);        
    }
}
