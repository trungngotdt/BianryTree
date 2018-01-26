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
        Node<int> item4;

        [SetUp]
        public void SetUp()
        {
            item = new Node<int>(7);
            item1 = new Node<int>(4);
            item2 = new Node<int>(5);
            item3 = new Node<int>(71);
            item4 = new Node<int>(50);
            nodeRoot = new Node<int>(15, new Node<int>(6), new Node<int>(23));
            nodeRoot.Insert(item);
            nodeRoot.Insert(item2);
            nodeRoot.Insert(item3);
            nodeRoot.Insert(item4);
            nodeRoot.Insert(item1);
            nodeRoot.Insert(new Node<int>(1));
            nodeRoot.Insert(new Node<int>(77));
            nodeRoot.AddRange(new Node<int>[] {
                new Node<int>(76), new Node<int>(75), new Node<int>(74), new Node<int>(98), new Node<int>(99),
                new Node<int>(43),new Node<int>(44),new Node<int>(51),new Node<int>(59),new Node<int>(60)
            });
            nodeRoot.Insert(null);
        }
        
        [Test]
        public void InsertAndContainsTest()
        {
            Node<string> st = new Node<string>();
            st.Insert(new Node<string>("S"));
            var item1C =  nodeRoot.Contains(item1);
            var item2C = nodeRoot.Contains(item3);

            var falseCon = nodeRoot.Contains(new Node<int>());
            var falseNull = nodeRoot.Contains(null);
            Assert.IsTrue(item1C);
            Assert.IsTrue(item2C);
            Assert.IsFalse(falseCon);
            Assert.IsFalse(falseNull);
        }

        [Test]
        public void GetMaxNodeAndGetMinNodeTest()
        {
            var max = nodeRoot.GetMax();
            var min = nodeRoot.GetMin();
            Assert.AreEqual(99, max);
            Assert.AreEqual(1, min);
            Assert.AreEqual(null, (new Node<string>()).GetMax());
            Assert.AreEqual(null, (new Node<string>()).GetMin());
        }

        [Test]
        public void SuccessorAndPredecessorTest()
        {
            nodeRoot.AddRange(new Node<int>[]{item });
            var suc = nodeRoot.Successor();

            var pred = nodeRoot.Predecessor();
            Assert.AreEqual(nodeRoot.Right.GetMin(), suc);
            Assert.AreEqual(nodeRoot.Left.GetMax(), pred);
        }

        [Test]
        public void RemoveTest()
        {
            var result1= nodeRoot.Remove(item);//Delete with no child
            var result2 = nodeRoot.Remove(item1);//Delete with one child (Left)
            var result7 = nodeRoot.Remove(new Node<int>(59));//Delete with one child (Right)
            var result3 = nodeRoot.Remove(item3);//Delete with  two chid
            var result4 = nodeRoot.Remove(null);//Delete with null paramater
            var result5 = nodeRoot.Remove(new Node<int>(1000));//Doesn't have element
            var result6 = nodeRoot.Remove(nodeRoot);//Delete root
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsFalse(result4);
            Assert.IsFalse(result5);
            Assert.IsTrue(result6);
            Assert.IsFalse(nodeRoot.Contains(new Node<int>(7)));
            Assert.IsFalse(nodeRoot.Contains(new Node<int>(4)));
            Assert.IsFalse(nodeRoot.Contains(new Node<int>(59)));
            Assert.IsFalse(nodeRoot.Contains(new Node<int>(71)));
            Assert.IsFalse(nodeRoot.Contains(new Node<int>(15)));
        }

        [Test]
        public void FindParentTest()
        {
            var result = nodeRoot.FindParent(new Node<int>(43));
            var result1 = nodeRoot.FindParent(null);
            var result2 = nodeRoot.FindParent(new Node<int>(10000));
            Assert.AreSame(item4, result.Item1);
            Assert.AreEqual(-1, result.Item2);
            Assert.IsNull(result1);
            Assert.IsNull(result2);
        }

        [Test]
        public void FindNodeTest()
        {
            Node<int> result = nodeRoot.FindNode(item);
            Node<int> result1 = nodeRoot.FindNode(null);
            Node<int> result2 = nodeRoot.FindNode(new Node<int>(10000));
            Assert.IsTrue(new Node<int>(7).CompareTo( result)==0);
            Assert.IsNull(result1);
            Assert.IsNull(result2);

        }
    }
}
