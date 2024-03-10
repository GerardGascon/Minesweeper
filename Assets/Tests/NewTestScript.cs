using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void RevealCell() {
        var sut = new MineSweeper(new Vector2Int(10,10), new Vector2Int(0, 0));
        sut.Reveal(4, 1);
        
        Assert.IsTrue(sut.IsRevealed(4, 1));
    }
    [Test]
    public void CellIsNotRevealed_ByDefault()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        Assert.IsFalse(sut.IsRevealed(5, 1));
    }
    [Test]
    public void CheckIfCellHasMine() {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(3,4));
        Assert.IsTrue(sut.HasMineIn(3,4));
    }
    [Test]
    public void CheckIfCellHasNoMine()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0,0));
        Assert.IsFalse(sut.HasMineIn(3, 4));
    }
    [Test]
    public void DetectOneMine_IfAdjacent()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(2, 2));
        Assert.AreEqual(1, sut.CheckAdjacentMines(1, 1));
    }
    [Test]
    public void DetectZeroMines_IfNotAdjacent()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(2, 2));
        Assert.AreEqual(0, sut.CheckAdjacentMines(4, 4));
    }
    [Test]
    public void GetCornerAdjacentCells()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(2, 2));
        Assert.AreEqual(
            new List<Vector2Int> { new(0, 1), new(1, 0), new(1, 1) },
            sut.AdjacentOf(0, 0));
    }
    [Test]
    public void GetNonCornerAdjacentCells() {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(1, 1));
        
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(0, 0)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(0, 1)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(0, 2)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(1, 0)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(1, 2)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(2, 0)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(2, 1)));
        Assert.IsTrue(sut.AdjacentOf(1, 1).Contains(new Vector2Int(2, 2)));
    }
    [Test]
    public void CheckIfTwoAdjacentMines()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new List<Vector2Int>{ new Vector2Int(0, 0), new Vector2Int(0, 2) });
        Assert.AreEqual(2, sut.CheckAdjacentMines(0, 1));
    }
    [Test]
    public void NotFlaggedByDefault() {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0,0));
        Assert.IsFalse(sut.IsFlagged(0, 0));
    }
    [Test]
    public void CellIsFlagged() {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        sut.Flag(0, 1);
        Assert.IsTrue(sut.IsFlagged(0, 1));
    }
    [Test]
    public void NoFlagAfterUnflag()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        sut.Flag(0, 0);
        sut.Unflag(0, 0);
        Assert.IsFalse(sut.IsFlagged(0, 0));
    }
    [Test]
    public void NotLostByDefault()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        Assert.IsFalse(sut.HaveWeLost());
    }
    [Test]
    public void Lose_IfMineRevealed()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        sut.Reveal(0,0);
        Assert.IsTrue(sut.HaveWeLost());
    }
    [Test]
    public void NotLose_IfEmptyCellRevealed()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        sut.Reveal(0, 1);
        Assert.IsFalse(sut.HaveWeLost());
    }
    [Test]
    public void NotWin_IfNoCellsRevealed()
    {
        var sut = new MineSweeper(new Vector2Int(10, 10), new Vector2Int(0, 0));
        Assert.IsFalse(sut.HaveWeWon());
    }
    [Test]
    public void Win_IfEmptyCellsRevealed()
    {
        var sut = new MineSweeper(new Vector2Int(2, 1), new Vector2Int(0, 0));
        sut.Reveal(1, 0);
        Assert.IsTrue(sut.HaveWeWon());
    }
    
    [Test]
    public void NotWin_IfNotAllEmptyCellsRevealed()
    {
        var sut = new MineSweeper(new Vector2Int(2, 2), new Vector2Int(0, 0));
        sut.Reveal(1, 0);
        Assert.IsFalse(sut.HaveWeWon());
    }
}
