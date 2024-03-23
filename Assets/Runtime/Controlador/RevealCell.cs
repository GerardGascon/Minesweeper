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

    public void Flag(int x, int y)
    {
        if (!sweeper.CanBeFlagged(x, y))
            return;
        sweeper.Flag(x, y);
        vista.UpdateCell();
    }

    public void Unflag(int x, int y) {
        if(!sweeper.IsFlagged(x, y))
            return;
        sweeper.Unflag(x, y);
        vista.UpdateCell();
    }
}
public interface View {
    void UpdateCell();
}

