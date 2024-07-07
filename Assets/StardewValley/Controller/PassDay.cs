using System;
using StardewValley.Domain;

public class PassDay
{
    private Farm farm;
    private FarmRenderer view;

    public PassDay(Farm farm, FarmRenderer view)
    {
        this.farm = farm;
        this.view = view;
    }

    public void Run()
    {
        farm.PassDay();
        view.UpdateFarm(farm);
    }
}