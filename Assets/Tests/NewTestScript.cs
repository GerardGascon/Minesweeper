using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewTestScriptSimplePasses() {
        var sut = new MineSweeper(new Vector2Int(0, 0));
        sut.Reveal(4, 1);
        
        Assert.IsTrue(sut.IsRevealed(4, 1));
    }
    [Test]
    public void asdaosdoj()
    {
        var sut = new MineSweeper(new Vector2Int(0, 0));
        Assert.IsFalse(sut.IsRevealed(5, 1));
    }
    [Test]
    public void asdaosdo23423k() {
        var sut = new MineSweeper(new Vector2Int(3,4));
        Assert.IsTrue(sut.HasMineIn(3,4));
    }
}
