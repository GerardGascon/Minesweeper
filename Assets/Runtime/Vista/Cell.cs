using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Text cellText;
    public Vector2Int cellPosition;
    public RevealCell revealCell;
    public ToggleFlag toggleFlag;
    private ButtonClick buttonClick;

    private void Awake()
    {
        buttonClick=GetComponent<ButtonClick>();
        buttonClick.leftClick += OnLeftClickCell;
        buttonClick.rightClick += OnRightClickCell;
    }
    private void OnLeftClickCell()
    {
        revealCell.Reveal(cellPosition.x, cellPosition.y);
    }
    private void OnRightClickCell()
    {
        toggleFlag.Execute(cellPosition.x,cellPosition.y);
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

}
