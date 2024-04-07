using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sladkfjñlasdf : MonoBehaviour
{
    [SerializeField] private GameObject CellPrefab;
   

    public void UpdateCell(MineSweeper sweeper)
    {
        string siadjoas = "";
        for (int i = sweeper.Size.x - 1; i >= 0; i--)
        {
            for (int j = 0; j < sweeper.Size.y; j++)
                siadjoas += ObtainCellValue(sweeper, i, j);

            siadjoas += "\n";
        }

        //screenText.text = siadjoas;
    }

    private string ObtainCellValue(MineSweeper sweeper, int i, int j)
    {
        if (!sweeper.IsRevealed(i, j))
        {
            if (sweeper.IsFlagged(i, j))
                return "A";
            return "x";
        }

        return "o";
    }
}
