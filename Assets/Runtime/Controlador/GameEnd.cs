using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd
{
    private View vista;
    private MineSweeper sweeper;
    public GameEnd(View vista, MineSweeper sweeper)
    {
        this.vista = vista;
        this.sweeper = sweeper;
    }

    public void CheckGameEnd()
    {
        if (sweeper.HaveWeLost())
            vista.GameEnd("Has perdido");
        if (sweeper.HaveWeWon())
            vista.GameEnd("Has ganado");
    }
}
