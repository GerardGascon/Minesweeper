using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ioasjdasoi : MonoBehaviour, View
{
    [SerializeField]
    Text screenText;
    [SerializeField]
    InputField input;
    [SerializeField]
    Button reveal;
    [SerializeField]
    Button flag;
    [SerializeField]
    Text endScreen;
    MineSweeper sweeper;
    RevealCell _revealCell;
    ToggleFlag _toggleFlag;
    private void Start()
    {
        sweeper = new MineSweeper(new Vector2Int(10,10),new Vector2Int(0,0));
        _revealCell = new RevealCell(this, sweeper);
        _toggleFlag = new ToggleFlag(this, sweeper);
        reveal.onClick.AddListener(RevealCell);
        flag.onClick.AddListener(FlagCell);
        UpdateCell();
    }

    private void FlagCell() {
        var x = input.text.Split(',')[0];
        var y = input.text.Split(',')[1];
        _toggleFlag.Execute(int.Parse(x), int.Parse(y));
    }

    private void RevealCell()
    {
        var x = input.text.Split(',')[0];
        var y = input.text.Split(',')[1];
        _revealCell.Reveal(int.Parse(x), int.Parse(y));
    }

    public void UpdateCell()
    {
        string siadjoas = "";
        for (int i = sweeper.Size.x - 1; i >= 0; i--)
        {
            for (int j = 0; j < sweeper.Size.y; j++)
            {
                if (!sweeper.IsRevealed(i, j))
                {
                    if (sweeper.IsFlagged(i, j))
                    {
                        siadjoas += "A";
                        continue;
                    }
                    siadjoas += "x";
                    continue;
                }
                else
                {
                    siadjoas += "o";
                    continue;
                }
            }

            siadjoas += "\n";
        }

        screenText.text = siadjoas;
    }

    public void GameEnd(string text)
    {
        endScreen.gameObject.SetActive(true);
        endScreen.text = text;
    }
}
