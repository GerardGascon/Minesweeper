using UnityEngine;

public class Cell
{
    public bool isWet;
    public bool isPlanted;
    public bool isGrown;
    public int growStage;


    public void PassDay()
    {
        if (isPlanted && isWet) {
            isGrown = true;
            growStage++;
        }

        isWet = false;
    }
}
