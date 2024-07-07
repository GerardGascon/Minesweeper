using StardewValley.Domain;

public class RendererMock : FarmRenderer {
    public Farm receivedFarm { private set; get; }

    public void UpdateFarm(Farm domain)
    {
        this.receivedFarm = domain;
    }
}