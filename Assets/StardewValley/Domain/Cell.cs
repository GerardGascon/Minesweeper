using UnityEngine;

public class Cell
{
    public bool isWet;
    public bool isPlanted;
    public bool isGrown;


    public void PassDay()
    {
        if (isPlanted && isWet)
            isGrown = true;

        isWet = false;
    }
}
