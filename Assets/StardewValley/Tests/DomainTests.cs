using NUnit.Framework;

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
		Assert.IsTrue(sut.HasSeed(0, 0));
    }

	[Test]
	public void IsNotPlanted()
	{
		Farm sut = new();
		Assert.IsFalse(sut.HasSeed(0, 0));
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

}