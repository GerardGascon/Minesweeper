using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MineSweeper {
	private List<Vector2Int> cellsRevealed = new();
	private List<Vector2Int> flags = new();
	private List<Vector2Int> mines = new();
	private Vector2Int size;

    public MineSweeper(Vector2Int size, Vector2Int Mina)
    {
		this.size = size;
		mines.Add(Mina);
    }

    public MineSweeper(Vector2Int size, List<Vector2Int> minas)
    {
		this.size = size;
        mines.AddRange(minas);
    }

    public void Reveal(int x, int y)
    {
        cellsRevealed.Add(new Vector2Int(x, y));
    }

    public bool IsRevealed(int x, int y) => cellsRevealed.Contains(new Vector2Int(x, y));

	public bool HasMineIn(int x, int y) => mines.Contains(new Vector2Int(x, y));

	public int CheckAdjacentMines(int x, int y) => AdjacentOf(x, y).Count(cell => HasMineIn(cell.x, cell.y));

	public List<Vector2Int> AdjacentOf(int x, int y) {
		var result = new List<Vector2Int>();

		for (var i = x - 1; i <= x + 1; i++) {
			for (var j = y - 1; j <= y + 1; j++) {
				if (i < 0 || j < 0)
					continue;
				if (i == x && j == y)
					continue;

				result.Add(new Vector2Int(i, j));
			}
		}

		return result;
	}

	public void Flag(int x, int y) {
		flags.Add(new Vector2Int(x, y));
    }

    public bool IsFlagged(int x, int y) {
	    return flags.Contains(new Vector2Int(x, y));
    }

    public void Unflag(int x, int y)
    {
		flags.Remove(new Vector2Int(x, y));
    }

    public bool HaveWeLost()
    {
		return mines.Intersect(cellsRevealed).Any();
    }

    public bool HaveWeWon()
    {
		return false;
    }
}