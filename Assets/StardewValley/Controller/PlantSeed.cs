public class PlantSeed
{
    private Farm domain;
    private FarmRenderer view;

    public PlantSeed(Farm farm, FarmRenderer view)
    {
        this.domain = farm;
        this.view = view;
    }

    public void Run(int x, int y)
    {
        domain.PlantSeed(x, y);
        view.UpdateFarm(domain);
    }
}
