using NUnit.Framework;
using UnityEngine;

public class DomainTests
{
    [Test]
    public void asdlñkfasldf()
    {
        Farm sut = new Farm();
        sut.Water(0, 0);
        Assert.IsTrue(sut.IsWet(0, 0));
    }
}
