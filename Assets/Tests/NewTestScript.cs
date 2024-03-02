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
        var sut = new MineSweeper();
        sut.Reveal(4, 1);
        
        Assert.IsTrue(sut.IsRevealed(4, 1));
    }
    [Test]
    public void asdaosdoj()
    {
        var sut = new MineSweeper();
        Assert.IsFalse(sut.IsRevealed(5, 1));
    }
}
