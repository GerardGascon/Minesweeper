using StardewValley.Domain;

public class Water {
    private Farm domain;
    private FarmRenderer view;

    public Water(Farm farm, FarmRenderer view) {
        this.domain = farm;
        this.view = view;
    }

    public void Run(int x, int y) {
        domain.Water(x, y);
        view.UpdateFarm(domain);
    }
}