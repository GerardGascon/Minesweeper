using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCell
{
    private View vista;
    private MineSweeper sweeper;

    public RevealCell(View vista, MineSweeper sweeper)
    {
        this.vista = vista;
        this.sweeper = sweeper;
    }
    public void Reveal(int x,int y)
    {
        if (!sweeper.CanBeRevealed(x,y))
            return;
        if (sweeper.RevealedCells() == 0)
            sweeper.ResetMines(x, y);

        sweeper.Reveal(x,y);
        vista.UpdateBoard();
    }
}
public interface View {
    void UpdateBoard();
    void GameEnd(string text);
}

