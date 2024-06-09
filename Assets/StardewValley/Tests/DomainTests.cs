using NUnit.Framework;
using UnityEngine;

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
	public void aspdioruewq() {
		Farm farm = new();
		RendererMock view = new();
		Water sut = new(farm, view);

		sut.Run(2, 1);

		Assert.IsTrue(view.receivedFarm.IsWet(2, 1));
	}
}

public class RendererMock : FarmRenderer {
	public Farm receivedFarm { private set; get; }
}

public interface FarmRenderer { }

public class Water {
	public Water(Farm farm, FarmRenderer view) {
		throw new System.NotImplementedException();
	}

	public void Run(int x, int y) {
		throw new System.NotImplementedException();
	}
}