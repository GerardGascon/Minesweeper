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
        sweeper.Reveal(x,y);
        vista.UpdateCell();
    }
}
public interface View {
    void UpdateCell();
    void GameEnd(string text);
}

