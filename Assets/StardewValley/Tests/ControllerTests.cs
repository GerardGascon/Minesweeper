using NUnit.Framework;

public class ControllerTests {
	[Test]
	public void WaterTerrain() {
		Farm farm = new();
		RendererMock view = new();
		Water sut = new(farm, view);

		sut.Run(2, 1);

		Assert.IsTrue(view.receivedFarm.IsWet(2, 1));
	}
	[Test]
	public void PassDay()
	{
		Farm farm = new();
		farm.Water(3,3);
		RendererMock view = new();
		PassDay sut = new(farm, view);
		
		sut.Run();

		Assert.IsFalse(view.receivedFarm.IsWet(3, 3));
	}
}