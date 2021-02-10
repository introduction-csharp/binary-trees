using System.Collections.Generic;
using BinaryTreesExample.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreesExample.Tests
{
    [TestClass]
    public class TestRemove
    {
        [TestMethod]
        public void TestRemoveLeaf()
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new List<int> { 80, 60, 50, 70, 100, 64, 90, 110, 120, 100 })
                bt.Add(i);
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(844, bt.Sum);
            Assert.IsTrue(bt.Remove(64));
            Assert.AreEqual(9, bt.Count);
            Assert.AreEqual(780, bt.Sum);
        }

        [TestMethod]
        public void TestRemoveSingleSubtree()
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new List<int> { 80, 60, 50, 70, 100, 64, 90, 110, 120, 100 })
                bt.Add(i);
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(844, bt.Sum);
            Assert.IsTrue(bt.Remove(70));
            Assert.AreEqual(9, bt.Count);
            Assert.AreEqual(774, bt.Sum);
        }

        [TestMethod]
        public void TestRemoveRightSubtree()
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new List<int> { 80, 60, 50, 70, 100, 74, 90, 110, 120, 100 })
                bt.Add(i);
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(854, bt.Sum);
            Assert.IsTrue(bt.Remove(70));
            Assert.AreEqual(9, bt.Count);
            Assert.AreEqual(784, bt.Sum);
        }

        [TestMethod]
        public void TestRemoveBothSubtree()
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new List<int> { 80, 60, 50, 70, 100, 64, 90, 110, 120, 100 })
                bt.Add(i);
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(844, bt.Sum);
            Assert.IsTrue(bt.Remove(110));
            Assert.AreEqual(9, bt.Count);
            Assert.AreEqual(734, bt.Sum);
        }

        [TestMethod]
        public void TestRemoveBothSubtreeDuplicatedValue()
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new List<int> { 80, 60, 50, 70, 100, 64, 90, 110, 120, 100 })
                bt.Add(i);
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(844, bt.Sum);
            Assert.IsTrue(bt.Remove(100));
            Assert.AreEqual(9, bt.Count);
            Assert.AreEqual(744, bt.Sum);
        }

        [TestMethod]
        public void TestRemoveNotThere()
        {
            BinaryTree bt = new BinaryTree();
            foreach (int i in new List<int> { 80, 60, 50, 70, 100, 64, 90, 110, 120, 100 })
                bt.Add(i);
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(844, bt.Sum);
            Assert.IsFalse(bt.Remove(75));
            Assert.AreEqual(10, bt.Count);
            Assert.AreEqual(844, bt.Sum);
        }


    }
}
