using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ioasjdasoi : MonoBehaviour
{
    [SerializeField]
    Text screen;
    [SerializeField]
    InputField input;
    [SerializeField]
    Button reveal;
    MineSweeper sweeper;
    private void Start()
    {
        sweeper = new MineSweeper(new Vector2Int(5,5),new Vector2Int(0,0));
        reveal.onClick.AddListener(RevealCell);
    }
    private void Update()
    {
        string siadjoas="";
        for (int i = 0; i < sweeper.Size.x; i++)
        {
            for (int j = 0; j < sweeper.Size.y; j++)
            {
                if (!sweeper.IsRevealed(i,j))
                {
                    siadjoas+="x";
                    continue;
                }
                else
                {
                    siadjoas += "o";
                    continue;
                }
            }
        }
    }
    private void RevealCell()
    {
        var x = input.text.Split(',')[0];
        var y = input.text.Split(',')[1];
        sweeper.Reveal(int.Parse(x), int.Parse(y));
    }
}
