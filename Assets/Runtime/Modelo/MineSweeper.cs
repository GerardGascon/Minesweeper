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
    public Vector2Int Size=>size;

    public MineSweeper(Vector2Int size, Vector2Int Mina) : this(size,new List<Vector2Int> { Mina}) { }

    public MineSweeper(Vector2Int size, List<Vector2Int> minas)
    {
        if (!HasMinSize(ref size))
            throw new ArgumentException("El tamaño del tablero es menor al minimo");
        if (minas.Distinct().Count() != minas.Count())
            throw new ArgumentException("Minas duplicadas");
        if (minas.Count() >= (size.x * size.y))
            throw new ArgumentException("Demasiadas minas");
        if(minas.Count()<1)
            throw new ArgumentException("No hay minas");

        this.size = size;
        mines.AddRange(minas);

        static bool HasMinSize(ref Vector2Int size)
        {
            return size.x >= 1 && size.y >= 1;
        }
    }

    public void Reveal(int x, int y)
    {
        if (IsRevealed(x, y))
            throw new InvalidOperationException("La casilla ya está revelada");
        if (GameOver())
            throw new InvalidOperationException("La partida ha terminado");
        if (CellOutOfBounds(x,y))
			throw new ArgumentOutOfRangeException("Posición a revelar está fuera de los margenes");
		
        cellsRevealed.Add(new Vector2Int(x, y));

        CheckCascadeReveal(x, y);
    }
    public bool CanBeRevealed(int x,int y)
    {
        return !IsRevealed(x, y) && !GameOver() && !CellOutOfBounds(x, y);
    }

    private void CheckCascadeReveal(int x, int y)
    {
        if (CheckAdjacentMines(x, y) != 0)
            return;
        if (HasMineIn(x, y))
            return;
            
        List<Vector2Int> adjacentCells = AdjacentOf(x, y);

            foreach (Vector2Int c in adjacentCells)
            {
                if(!IsRevealed(c.x, c.y))
                    Reveal(c.x, c.y);
            }

    }

    public bool IsRevealed(int x, int y)
    {
        if (CellOutOfBounds(x, y))
            throw new ArgumentException("This cell is out of bounds"+x+","+y);
        return cellsRevealed.Contains(new Vector2Int(x, y));
    }

    public bool HasMineIn(int x, int y) => mines.Contains(new Vector2Int(x, y));

	public int CheckAdjacentMines(int x, int y) => AdjacentOf(x, y).Count(cell => HasMineIn(cell.x, cell.y));

	public List<Vector2Int> AdjacentOf(int x, int y) {
        if (CellOutOfBounds(x, y))
            throw new InvalidOperationException("Posición a marcar está fuera de los margenes");
        var result = new List<Vector2Int>();

		for (var i = x - 1; i <= x + 1; i++) {
			for (var j = y - 1; j <= y + 1; j++) {
                if (CellOutOfBounds(i, j))
                    continue;
				if (IsItself())
					continue;

                bool IsItself() => i == x && j == y;

                result.Add(new Vector2Int(i, j));
			}
		}

		return result;
	}

	public void Flag(int x, int y)
    {
        if (GameOver())
            throw new InvalidOperationException("La partida ha terminado");
        if (CellOutOfBounds(x, y))
            throw new InvalidOperationException("Posición a marcar está fuera de los margenes");
        if (IsFlagged(x, y))
            throw new InvalidOperationException("La casilla ya está marcada");

        flags.Add(new Vector2Int(x, y));
    }

    public bool CanBeFlagged(int x, int y)
    {
        return !IsFlagged(x, y) && !GameOver() && !CellOutOfBounds(x, y);
    }

    private bool CellOutOfBounds(int x, int y)
    {
        return x >= size.x || y >= size.y || x < 0 || y < 0;
    }

    public bool IsFlagged(int x, int y) {
	    return flags.Contains(new Vector2Int(x, y));
    }

    public void Unflag(int x, int y)
    {
        if(GameOver())
            throw new InvalidOperationException("La partida ha terminado");
        if (CellOutOfBounds(x, y))
            throw new InvalidOperationException("Posición a desmarcar está fuera de los margenes");
        if (!IsFlagged(x, y))
            throw new InvalidOperationException("La casilla no está marcada");

        flags.Remove(new Vector2Int(x, y));
    }

    public bool GameOver()
    {
        return HaveWeLost() || HaveWeWon();
    }

    public bool HaveWeLost()
    {
		return mines.Intersect(cellsRevealed).Any();
    }

    public bool HaveWeWon() {
	    int cells = size.x * size.y;
	    int unrevealedCells = cells - cellsRevealed.Count;
	    
		return unrevealedCells == mines.Count;
    }


}