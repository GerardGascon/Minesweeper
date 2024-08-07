using NUnit.Framework;
using StardewValley.Domain;

public class DomainTests {
	[Test]
	public void WaterTerrain() {
		Farm sut = new Farm();
		sut.Water(0, 0);
		Assert.IsTrue(sut.IsWet(0, 0));
	}

	[Test]
	public void NotWateredTerrain() {
		Farm sut = new Farm();
		Assert.IsFalse(sut.IsWet(0, 0));
	}

	[Test]
	public void CheckTerrainNotWatered() {
		Farm sut = new Farm();
		sut.Water(1, 0);
		Assert.IsFalse(sut.IsWet(0, 0));
	}

	[Test]
	public void DryTerrainAfterDayPassed() {
		Farm sut = new();
		sut.Water(0, 0);
		sut.PassDay();
		Assert.IsFalse(sut.IsWet(0, 0));
	}

	[Test]
	public void IsPlanted()
    {
		Farm sut = new();
		sut.PlantSeed(0, 0);
		Assert.IsTrue(sut.IsPlanted(0, 0));
    }

	[Test]
	public void IsNotPlanted()
	{
		Farm sut = new();
		Assert.IsFalse(sut.IsPlanted(0, 0));
	}

	[Test]
	public void SeedGrowsWhenWatered() {
		Farm sut = new();

		sut.PlantSeed(0, 1);
		sut.Water(0, 1);
		sut.PassDay();

		Assert.IsTrue(sut.IsGrown(0, 1));
	}

	[Test]
	public void SeedNotGrowingWhenNotWatered()
	{
        Farm sut = new();

        sut.PlantSeed(0, 1);
        sut.PassDay();

		Assert.IsFalse(sut.IsGrown(0, 1));
    }

	[Test]
	public void SeedNotGrowingWhenNotPlanted()
	{
		Farm sut = new();

		sut.Water(0, 1);
		sut.PassDay();

		Assert.IsFalse(sut.IsGrown(0, 1));
	}

	[Test]
	public void GrownStageDefaultAtZero() {
		Farm sut = new();

		Assert.AreEqual(0, sut.GetSoilStage(0, 2));
	}

	[Test]
	public void GrownStageAtOne_AfterDayWhenPlanted() {
		Farm sut = new();

		int previousStage = sut.GetSoilStage(0, 2);

		sut.Water(0, 2);
		sut.PlantSeed(0, 2);
		sut.PassDay();

		Assert.AreEqual(previousStage + 1, sut.GetSoilStage(0, 2));
	}
}