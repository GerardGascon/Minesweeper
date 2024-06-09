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
}