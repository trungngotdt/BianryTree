using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BinaryTree;

namespace BinaryTreeTest
{
    [TestFixture]
    public class NodeTest
    {
        Node<int> nodeRoot ;
        Node<int> item;//= new Node<int>(3);
        Node<int> item1;//= new Node<int>(1);
        Node<int> item2;//= new Node<int>(4);
        Node<int> item3;//= new Node<int>(-4);

        [SetUp]
        public void SetUp()
        {
            item = new Node<int>(3);
            item1 = new Node<int>(1);
            item2 = new Node<int>(4);
            item3 = new Node<int>(-4);
            nodeRoot = new Node<int>(2, new Node<int>(1), new Node<int>(3));
        }
        
        [Test]
        public void InsertAndContainsTest()
        {
            nodeRoot.Insert(item2);
            nodeRoot.Insert(item3);
            nodeRoot.Insert(item1);
            nodeRoot.Insert(null);
            Node<string> st = new Node<string>();
            st.Insert(new Node<string>("S"));
            var item1C =  nodeRoot.Contains(item1);
            var item2C = nodeRoot.Contains(item2);
            var falseCon = nodeRoot.Contains(new Node<int>());
            Assert.IsTrue(item1C);
            Assert.IsTrue(item2C);
            Assert.IsFalse(falseCon);
        }

        [Test]
        public void GetMaxNodeAndGetMinNodeTest()
        {
            nodeRoot.Insert(item2);
            nodeRoot.Insert(item3);
            nodeRoot.Insert(item1);
            var max = nodeRoot.GetMax();
            var min = nodeRoot.GetMin();
            Assert.AreEqual(4, max);
            Assert.AreEqual(-4, min);
            Assert.AreEqual(null, (new Node<string>()).GetMax());
            Assert.AreEqual(null, (new Node<string>()).GetMin());
        }

        [Test]
        public void SuccessorAndPredecessorTest()
        {
            nodeRoot.Insert(item2);
            nodeRoot.Insert(item3);
            nodeRoot.Insert(item1);
            nodeRoot.Insert(item);
            nodeRoot.AddRange(new Node<int>[]{item });
            var suc = nodeRoot.Successor();

            var pred = nodeRoot.Predecessor();
            Assert.AreEqual(nodeRoot.Right.GetMin(), suc);
            Assert.AreEqual(nodeRoot.Letf.GetMax(), pred);
        }

        [Test]
        public void RemoveTest()
        {

        }
    }
}
