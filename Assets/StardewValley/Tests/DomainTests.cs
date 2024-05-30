using NUnit.Framework;
using UnityEngine;

public class DomainTests
{
    [Test]
    public void WaterTerrain()
    {
        Farm sut = new Farm();
        sut.Water(0, 0);
        Assert.IsTrue(sut.IsWet(0, 0));
    }

    [Test]
    public void NotWateredTerrain()
    {
        Farm sut = new Farm();
        Assert.IsFalse(sut.IsWet(0, 0));
    }
}
