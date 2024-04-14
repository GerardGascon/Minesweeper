using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFlag
{
    private View vista;
    private MineSweeper sweeper;
    public ToggleFlag(View vista, MineSweeper sweeper)
    {
        this.vista = vista;
        this.sweeper = sweeper;
    }
    public void Execute(int x,int y)
    {
        if(sweeper.IsFlagged(x,y))
        {
            Unflag(x,y);
        }
        else
        {
            Flag(x,y);
        }
    }
    private void Flag(int x, int y)
    {
        if (!sweeper.CanBeFlagged(x, y))
            return;
        sweeper.Flag(x, y);
        vista.UpdateCell(sweeper);
    }

    private void Unflag(int x, int y)
    {
        sweeper.Unflag(x, y);
        vista.UpdateCell(sweeper);
    }
}
