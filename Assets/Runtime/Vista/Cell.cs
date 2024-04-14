using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour, View
{
    [SerializeField] private Text cellText;
    public Vector2Int cellPosition;
    public RevealCell revealCell;

    private void Start()
    {
        
    }
    public void OnClickCell()
    {
        Debug.Log("Me han clicado: (" + cellPosition.x + "-" + cellPosition.y + ")");
        //Llamar a MineSweeper y decirle que me han clicado y cual es mi posicion

        revealCell.Reveal(cellPosition.x, cellPosition.y);
    }

    public void SetCellPosition(int i, int j)
    {
        cellPosition.x = i;
        cellPosition.y = j;
    }

    public void Configure(MineSweeper sweeper, int i, int j)
    {
        cellText.text = CharacterAt(sweeper, i, j);
    }

    private string CharacterAt(MineSweeper sweeper, int i, int j)
    {
        if (!sweeper.IsRevealed(i, j))
        {
            if (sweeper.IsFlagged(i, j))
                return "A";
            return "x";
        }
        else
        {
            if (sweeper.HasMineIn(i, j))
                return "*";
            else
                return sweeper.CheckAdjacentMines(i, j).ToString();
        }
    }

    public void UpdateCell(MineSweeper sweeper)
    {
        CharacterAt(sweeper, cellPosition.x, cellPosition.y);
    }

    public void GameEnd(string text)
    {
        
    }
}
