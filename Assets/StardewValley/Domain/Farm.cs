
public class Farm
{
    private bool isWet;


    public void Water(int x, int y)
    {
        isWet = true;
    }

    public bool IsWet(int x, int y)
    {
        return isWet;
    }
}
